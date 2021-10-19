using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ProjekLab.Repository
{
    public class ReviewRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();
        public static List<Review> GetShowReview(int showId)
        {
            return (from x in db.TransactionHeaders
                    join y in db.TransactionDetails on x.Id equals y.TransactionHeaderId
                    join z in db.Reviews on y.Id equals z.TransactionDetailId
                    where x.ShowId == showId
                    select z).ToList();
        }

        public static bool CheckReviewStatus(int tdId)
        {
            Review currReview = (from x in db.Reviews where x.TransactionDetailId == tdId select x).FirstOrDefault();
            if (currReview == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool AddReview(Review newReview)
        {
            if(newReview != null)
            {
                db.Reviews.Add(newReview);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateReview(Review currReview)
        {
            if(currReview != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteReview(Review currReview)
        {;
            if(currReview != null)
            {
                db.Reviews.Remove(currReview);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Review GetReview(int tdId)
        {
            return (from x in db.Reviews where tdId == x.TransactionDetailId select x).FirstOrDefault();
        }
    }
}