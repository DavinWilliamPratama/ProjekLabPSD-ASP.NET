using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Factory
{
    public class ReviewFactory
    {
        public static Review Create(int tdId, int rating, string desc)
        {
            Review newReview = new Review();
            newReview.TransactionDetailId = tdId;
            newReview.Rating = rating;
            newReview.Description = desc;
            return newReview;
        }
    }
}