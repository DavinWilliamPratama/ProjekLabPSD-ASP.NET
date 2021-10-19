using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int buyerId, int showId, DateTime showTime, DateTime createdTime, int qty)
        {
            TransactionHeader th = new TransactionHeader();
            th.BuyerId = buyerId;
            th.ShowId = showId;
            th.ShowTime = showTime;
            th.CreatedAt = createdTime;
            th.Quantity = qty;

            return th;
        }
    }
}