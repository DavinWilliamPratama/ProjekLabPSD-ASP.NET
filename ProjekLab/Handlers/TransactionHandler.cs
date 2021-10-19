using ProjekLab.Factory;
using ProjekLab.Model;
using ProjekLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Handlers
{
    public class TransactionHandler
    {
        public static bool AddTransaction(int buyerId, int showId, DateTime showTime, DateTime createdTime, string qty)
        {
            TransactionHeader th = TransactionHeaderFactory.Create(buyerId, showId, showTime, createdTime, int.Parse(qty));

            string tokenAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string token = "";
            Random rand = new Random();

            if (TransactionHeaderRepository.AddTransaction(th))
            {

                for (int i = 0; i < int.Parse(qty); i++)
                {
                    do
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            token = string.Concat(tokenAlpha[rand.Next(0, 25)].ToString(), token);

                        }
                    } while (CheckToken(token) == false);

                    TransactionDetail td = TransactionDetailFactory.Create(th.Id, 1, token);
                    TransactionDetailRepository.AddTransactionDetail(td);
                    token = "";
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteTransaction(int thId)
        {
            if (TransactionDetailRepository.DeleteTransactionDetail(thId) == true && TransactionHeaderRepository.DeleteTransactionHeader(thId) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CheckToken(string token)
        {
            return TransactionDetailRepository.CheckToken(token);
        }

        public static bool CheckTokenStatus(string token)
        {
            return TransactionDetailRepository.CheckTokenStatus(token);
        }

        public static bool UseToken(string token)
        {
            if (CheckToken(token) == false)
            {
                TransactionDetail td = TransactionDetailRepository.GetTdByToken(token);
                td.StatusId = 2;

                return TransactionDetailRepository.UseToken(td);            }
            else
            {
                return false;
            }
        }

        public static List<TransactionHeader> GetAllTransactionHeader(int userId)
        {
            return TransactionHeaderRepository.GetAllTransactionHeader(userId);
        }

        public static List<TransactionHeader> GetAllOrder(int userId)
        {
            return TransactionHeaderRepository.GetAllOrder(userId);
        }

        public static List<TransactionDetail> GetAllUnUsedToken(int thId)
        {
            return TransactionDetailRepository.GetAllUnUsedToken(thId);
        }


        public static List<TransactionDetail> GetAllUsedToken(int thId)
        {
            return TransactionDetailRepository.GetAllUsedToken(thId);
        }

        public static int FindTransactionHeaderId(int userId, string title, DateTime createdAt, DateTime showTime, int qty)
        {
            return TransactionHeaderRepository.FindTransactionHeaderId(userId, title, createdAt, showTime, qty);
        }

        public static int GetShowId(int thId)
        {
            return TransactionHeaderRepository.GetShowId(thId);
        }


        public static bool CheckTimeNow(DateTime now, int thId)
        {
            return TransactionHeaderRepository.CheckTimeNow(now, thId);
        }

        public static int GetTransactionHeaderId(int tdId)
        {
            return TransactionDetailRepository.GetTransactionHeaderId(tdId);
        }

        public static int GetThIdByToken(string token)
        {
            return TransactionDetailRepository.GetThIdByToken(token);
        }
    }
}