using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Factory
{
    public class ShowFactory
    {
        public static Show Create(string name, string url, int price, string description, int sellerId)
        {
            Show newShow = new Show();


            newShow.Name = name;

            newShow.Url = url;

            newShow.Price = price;

            newShow.Description = description;

            newShow.SellerId = sellerId;

            return newShow;

        }
    }
}
