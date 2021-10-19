using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionHeaderId, int statusId, string token)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionHeaderId = transactionHeaderId;
            td.StatusId = statusId;
            td.Token = token;

            return td;
        }
    }
}