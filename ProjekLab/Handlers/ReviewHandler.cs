using ProjekLab.Factory;
using ProjekLab.Model;
using ProjekLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Handlers
{
    public class ReviewHandler
    {
        public static List<Review> GetShowReview(int showId)
        {
            return ReviewRepository.GetShowReview(showId);
        }
        public static bool GetReviewStatus(string token)
        {
            int tdId = TransactionDetailRepository.GetTransactionDetailId(token);
            return ReviewRepository.CheckReviewStatus(tdId);
        }

        public static bool AddReview(string token, int rating, string desc)
        {
            int tdId = TransactionDetailRepository.GetTransactionDetailId(token);
            Review newReview = ReviewFactory.Create(tdId, rating, desc);
            return ReviewRepository.AddReview(newReview);
        }

        public static bool UpdateReview(string token, int rating, string desc)
        {
            int tdId = TransactionDetailRepository.GetTransactionDetailId(token);
            Review currReview = ReviewRepository.GetReview(tdId);
            if(currReview != null)
            {
                currReview.Rating = rating;
                currReview.Description = desc;

                ReviewRepository.UpdateReview(currReview);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteReview(string token)
        {
            int tdId = TransactionDetailRepository.GetTransactionDetailId(token);
            Review currReview = ReviewRepository.GetReview(tdId);

            if(currReview != null)
            {
                ReviewRepository.DeleteReview(currReview);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}