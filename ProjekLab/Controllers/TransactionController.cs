using ProjekLab.Handlers;
using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Controllers
{
    public class TransactionController
    {
        public static string AddOrder(int buyerId, int showId, DateTime showTime, DateTime createdTime, string qty)
        {
            int qtyInt;
            if (int.TryParse(qty, out qtyInt) == false)
            {
                return "Quantity must be numeric!";
            }
            else
            {
                qtyInt = int.Parse(qty);
                if (qtyInt < 1)
                {
                    return "Quantity must at least 1";
                }
            }

            if (ShowHandler.CheckShowTime(showId, showTime) == false)
            {
                return "Sorry this show at the selected date and time is unavailable";
            }
            else if (TransactionHandler.AddTransaction(buyerId, showId, showTime, createdTime, qty))
            {
                
                return "Transaction Success";

            }
            else
            {
                return "";
            }
        }

        public static string DeleteOrder(int thId)
        {
            if (TransactionHandler.DeleteTransaction(thId))
            {
                return "Transaction Cancelled!";
            }
            else
            {
                return "Error";
            }
            
        }

        public static List<TransactionHeader> GetAllTransactionHeader(int sellerId)
        {
            return TransactionHandler.GetAllTransactionHeader(sellerId);
        }

        public static List<TransactionHeader> GetAllOrder(int userId)
        {
            return TransactionHandler.GetAllOrder(userId);
        }

        public static List<TransactionDetail> GetAllUnUsedToken(int thId)
        {
            return TransactionHandler.GetAllUnUsedToken(thId);
        }

        public static List<TransactionDetail> GetAllUsedToken(int thId)
        {
            return TransactionHandler.GetAllUsedToken(thId);
        }

        public static int FindTransactionHeaderId(int userId, string title, DateTime createdAt, DateTime showTime, int qty)
        {
            return TransactionHandler.FindTransactionHeaderId(userId, title, createdAt, showTime, qty);
        }

        public static int GetThIdByToken(string token)
        {
            return TransactionHandler.GetThIdByToken(token);
        }

        public static bool CheckTokenStatus(string token)
        {
            return TransactionHandler.CheckTokenStatus(token);
        }

        public static bool UseToken(string token)
        {
            return TransactionHandler.UseToken(token);
        }

        public static int GetShowId(int thId)
        {
            return TransactionHandler.GetShowId(thId);
        }

        public static bool CheckTimeNow(DateTime now, int thId)
        {
            return TransactionHandler.CheckTimeNow(now, thId);
        }

        public static int GetTransactionHeaderId(int tdId)
        {
            return TransactionHandler.GetTransactionHeaderId(tdId);
        }

    }
}