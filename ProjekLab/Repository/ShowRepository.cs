using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Repository
{
    public class ShowRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();

        public static List<Show> GetAllShows()
        {
            return (from x in db.Shows select x).ToList();
        }

        public static List<Show> GetShow(int id)
        {
            return (from x in db.Shows where x.Id == id select x).ToList();
        }

        public static Show FindById(int id)
        {
            return (from x in db.Shows where x.Id == id select x).FirstOrDefault();
        }

        public static bool CheckShow(int showId, int sellerId)
        {
            Show show = (from x in db.Shows where showId == x.Id && sellerId == x.SellerId select x).FirstOrDefault();

            if(show != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Show> GetAllSellerShows(int sellerId)
        {
            return (from x in db.Shows where sellerId == x.SellerId select x).ToList();
        }

        public static bool AddShow(Show newShow)
        {
            if(newShow != null)
            {
                db.Shows.Add(newShow);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateShow(Show currShow)
        {
            if(currShow != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteShow (Show currShow)
        {
            if(currShow != null)
            {
                db.Shows.Remove(currShow);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Show GetShowById(int id)
        {
            return (from x in db.Shows where x.Id == id select x).FirstOrDefault();
        }

        public static string GetShowUrl(int showId)
        {
            Show show = db.Shows.Find(showId);
            return show.Url;
        }

        public static bool CheckShowName(int userId, string name)
        {
            Show show = (from x in db.Shows where x.SellerId == userId && x.Name == name select x).FirstOrDefault();
            if(show != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}