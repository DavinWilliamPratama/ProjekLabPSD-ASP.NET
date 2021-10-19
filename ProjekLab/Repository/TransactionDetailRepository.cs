using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Repository
{
    public class TransactionDetailRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();
        public static bool AddTransactionDetail(TransactionDetail td)
        {
            if (td != null)
            {
                db.TransactionDetails.Add(td);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteTransactionDetail(int thId)
        {
            List < TransactionDetail > delList = (from x in db.TransactionDetails where x.TransactionHeaderId == thId select x).ToList();

            if(delList != null)
            {
                foreach (TransactionDetail td in delList)
                {
                    db.TransactionDetails.Remove(td);
                }
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckToken(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails where x.Token == token select x).FirstOrDefault();

            if (td == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckTokenStatus(string token)
        {
            TransactionDetail td = GetTdByToken(token);

            if (td.StatusId == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static TransactionDetail GetTdByToken(string token)
        {
            return (from x in db.TransactionDetails where x.Token == token select x).FirstOrDefault();            
        }

        public static bool UseToken(TransactionDetail td) 
        {
            if(td != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetThIdByToken(string token)
        {
            return (from x in db.TransactionDetails where token == x.Token select x.TransactionHeaderId).FirstOrDefault();
        }


        public static List<TransactionDetail> GetAllUnUsedToken(int thId)
        {
            return (from x in db.TransactionDetails where x.TransactionHeaderId == thId && x.StatusId == 1 select x).ToList();
        }

        public static List<TransactionDetail> GetAllUsedToken(int thId)
        {
            return (from x in db.TransactionDetails where x.TransactionHeaderId == thId && x.StatusId == 2 select x).ToList();
        }

        public static string GetToken(int tdId)
        {
            return db.TransactionDetails.Find(tdId).Token;
        }

        public static bool CheckToken(int thId)
        {
            TransactionDetail td = (from x in db.TransactionHeaders
                                    join y in db.TransactionDetails on x.Id equals y.TransactionHeaderId
                                    where x.Id == thId && y.StatusId == 2
                                    select y).FirstOrDefault();
            if (td == null)
            {
                return true;
                //token unused
            }
            else
            {
                return false;
                // token used
            }
        }

        public static int GetTransactionHeaderId(int tdId)
        {
            return db.TransactionDetails.Find(tdId).TransactionHeaderId;
        }

        public static int GetTransactionDetailId(string token)
        {
            TransactionDetail td = GetTdByToken(token);
            return (from x in db.TransactionDetails where td.Token == token select x.Id).FirstOrDefault();
        }
    }
}