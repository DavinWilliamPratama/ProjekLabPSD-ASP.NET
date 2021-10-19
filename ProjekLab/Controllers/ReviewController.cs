using ProjekLab.Handlers;
using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Controllers
{
    public class ReviewController
    {
        public static List<Review> GetShowReview(int showId)
        {
            return ReviewHandler.GetShowReview(showId);
        }

        public static string GetShowAverageRating(int showId)
        {
            double avg = 0;
            
            if(ReviewHandler.GetShowReview(showId).Count == 0)
            {
                return "No Review for this movie yet!";
            }

            for (int i = 0; i < ReviewHandler.GetShowReview(showId).Count; i++)
            {
                avg = avg + ReviewHandler.GetShowReview(showId)[i].Rating;
            }

            avg = avg / ReviewHandler.GetShowReview(showId).Count;

            return "Average Rating: " + avg.ToString();
        }

        public static bool GetReviewStatus(string token)
        {
            return ReviewHandler.GetReviewStatus(token);
        }

        public static string isValid(string rating, string desc)
        {
            if(int.TryParse(rating, out int ratingInt) == false)
            {
                return "Rating must be numeric!";
            }
            else
            {
                if(ratingInt < 0 || ratingInt > 5)
                {
                    return "Rating must be between 1 to 5!";
                }
                if(desc.Length == 0)
                {
                    return "Description must be filled!";
                }
                return "Valid";
            }
        }

        public static string AddReview(string token, string rating, string desc)
        {
            if(isValid(rating, desc) == "Valid")
            {
                int ratingInt = int.Parse(rating);
                if(ReviewHandler.AddReview(token, ratingInt, desc))
                {
                    return "Rate Added Successfully!";
                }
                else
                {
                    return "Rate Not Added!";
                }
            }
            else
            {
                return isValid(rating, desc);
            }
        }

        public static string UpdateReview(string token, string rating, string desc)
        {
            if (isValid(rating, desc) == "Valid")
            {
                int ratingInt = int.Parse(rating);
                if (ReviewHandler.UpdateReview(token, ratingInt, desc))
                {
                    return "Rate Updated Successfully!";
                }
                else
                {
                    return "Rate Not Updated!";
                }
            }
            else
            {
                return isValid(rating, desc);
            }
        }

        public static string DeleteReview(string token)
        {
           if(ReviewHandler.DeleteReview(token))
            {
                return "Review Deleted!";
            }
            else
            {
                return "Review Not Deleted!";
            }
        }
    }
}