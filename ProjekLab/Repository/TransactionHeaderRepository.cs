using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Repository
{
    public class TransactionHeaderRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();
        public static bool CheckShowTime(int showId, DateTime date)
        {
            if ((from x in db.TransactionHeaders where showId == x.ShowId && date.CompareTo(x.ShowTime) == 0 select x).FirstOrDefault() != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool AddTransaction(TransactionHeader th)
        {
            if(th != null)
            {
                db.TransactionHeaders.Add(th);
                db.SaveChanges();
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteTransactionHeader(int thId)
        {
            TransactionHeader th = GetTransactionHeader(thId);
            if(th != null)
            {
                db.TransactionHeaders.Remove(th);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }


        public static int GetShowId(int thId)
        {
            TransactionHeader th = GetTransactionHeader(thId);

            return th.ShowId;
        }
        public static int FindTransactionHeaderId(int userId, string title, DateTime createdAt, DateTime showTime, int qty)
        {
            return int.Parse((from x in db.TransactionHeaders where x.BuyerId == userId && x.Show.Name == title && x.ShowTime.CompareTo(showTime) == 0 && x.Quantity == qty select x.Id).FirstOrDefault().ToString());
        }

        public static bool CheckTimeNow(DateTime now, int thId)
        {
            TransactionHeader th = db.TransactionHeaders.Find(thId);
            if(th.ShowTime.CompareTo(now) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static TransactionHeader GetTransactionHeader(int thId)
        {
            return db.TransactionHeaders.Find(thId);
        }

        public static List<TransactionHeader> GetAllOrder(int UserId)
        {
            return (from x in db.TransactionHeaders where x.BuyerId == UserId select x).ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeader(int userId)
        {
            return (from x in db.TransactionHeaders where x.Show.SellerId == userId select x).ToList();
        }
    }
}