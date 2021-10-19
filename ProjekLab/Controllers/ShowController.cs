using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjekLab.Handlers;

namespace ProjekLab.Controllers
{
    public class ShowController
    {
        public static List<Show> GetAllShows()
        {
            return ShowHandler.GetAllShows();
        }

        public static List<Show> GetAllSellerShows(int sellerId)
        {
            return ShowHandler.GetAllSellerShows(sellerId);
        }

        public static List<Show> GetShow(int id)
        {
            return ShowHandler.GetShow(id);
        }

        public static List<Show> GetShowReview(int id)
        {
            return ShowHandler.GetShow(id);
        }


        public static bool CheckShow(int showId, int sellerId)
        {
            return ShowHandler.CheckShow(showId, sellerId);
        }

        public static bool CheckShowTime(int showId, DateTime date)
        {
            return ShowHandler.CheckShowTime(showId, date);
        }


        public static string AddShow(string name, string url, string price, string description, int sellerId)
        {
            int priceInt;

            if (name.Length < 5) return "Product name must be at least 5 chars!";

            if (int.TryParse(price, out priceInt) == true)
            {
                if (priceInt < 999)
                {
                    return "Price must be atleast 1000!";
                }
            }
            else
            {
                return "Price must be numeric!";
            }

            if (description == null) return "Description must be filled!";

            ShowHandler.AddShow(name, url, priceInt , description, sellerId);

            return "Insert Success! ";
        }


        public static string UpdateShow(int userId, int showId, string name, string url, string price, string description)
        {
            int priceInt;

            if (name.Length < 5) return "Product name must be at least 5 chars!";

            if (ShowHandler.CheckShowName(userId, name) == false) return "Show Name must be unique";

            if (int.TryParse(price, out priceInt) == true)
            {
                if (priceInt < 999)
                {
                    return "Price must be atleast 1000!";
                }
            }
            else
            {
                return "Price must be numeric!";
            }

            if (description == null)
            {
                return "Description must be filled!";
            }

            if (ShowHandler.UpdateShow(showId, name, description, priceInt, url) == false)
            {
                return "Product with ID " + showId + " not found!";

            }

            return "Product with ID " + showId + " updated!";
        }

        public static string DeleteShow(int id)
        {
            if (ShowHandler.DeleteShow(id))
            {
                return "Product with ID " + id + " not found!";
            }
            return "Product with ID " + id + " deleted!";

        }

        public static String GetShowDetailById(int id, string label)
        {
            if (label.Equals("txtShowName"))
            {
                return "Show Name: " + ShowHandler.GetShowById(id).Name;
            }
            else if (label.Equals("txtShowPrice"))
            {
                return "Show Price: " + ShowHandler.GetShowById(id).Price;
            }
            else if (label.Equals("txtSellerName"))
            {
                return "Seller Name: " + ShowHandler.GetShowById(id).User.Name;
            }
            else if(label.Equals("txtShowDescription"))
            {
                return "Show Description: " + ShowHandler.GetShowById(id).Description;
            }
            else
            {
                return "";
            }
        }

        public static string GetShowUrl(int showId)
        {
            return ShowHandler.GetShowUrl(showId);
        }
    }
}