using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProjekLab.Factory;
using ProjekLab.Model;
using ProjekLab.Repository;

namespace ProjekLab.Handlers
{
    public class ShowHandler
    {
        public static Show FindById(int productID)
        {

            return ShowRepository.FindById(productID);
        }

        public static bool CheckShow(int showId, int sellerId)
        {
            return ShowRepository.CheckShow(showId, sellerId);
        }

        public static List<Show> GetAllShows()
        {
            return ShowRepository.GetAllShows();
        }

        public static List<Show> GetAllSellerShows(int sellerId)
        {
            return ShowRepository.GetAllSellerShows(sellerId);
        }

        public static List<Show> GetShow(int id)
        {
            return ShowRepository.GetShow(id);
        }

        public static bool CheckShowTime(int showId, DateTime date)
        {
            return TransactionHeaderRepository.CheckShowTime(showId, date);
        }

        public static bool AddShow(string name, string url, int price, string description, int sellerId)
        {

            Show newShow = ShowFactory.Create(name, url, price, description, sellerId);

            return ShowRepository.AddShow(newShow);
        }

        public static bool UpdateShow(int id, string name, string desc, int price, string url) 
        {
            Show currShow = ShowRepository.FindById(id);

            if(currShow == null)
            {
                return false;
            }

            currShow.Name = name;
            currShow.Price = price;
            currShow.Description = desc;
            currShow.Url = url;


            return ShowRepository.UpdateShow(currShow);
        }


        public static bool DeleteShow(int id)
        {
            Show show = ShowRepository.FindById(id);
            if (show == null)
            {
                //show not found
                return false;
            }
            return ShowRepository.DeleteShow(show);
        }

        public static Show GetShowById(int id)
        {
            return ShowRepository.GetShowById(id);
        }

        public static string GetShowUrl(int showId)
        {
            return ShowRepository.GetShowUrl(showId);
        }

        public static bool CheckShowName(int userId, string name)
        {
            return ShowRepository.CheckShowName(userId, name);
        }

    }
}