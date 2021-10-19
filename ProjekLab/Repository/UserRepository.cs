using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Repository
{
    public class UserRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();

        public static User InsertUser(User user)
        {
            if(user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }

        public static User GetUser(string username, string password)
        {
            User user = (from x in db.Users where x.Username == username && x.Password == password select x).FirstOrDefault();

            return user;
        }

        public static User GetUserById(int userId)
        {
            return db.Users.Find(userId);
        }

        public static bool MatchPassword(int userId, string password)
        {
            User user = db.Users.Find(userId);
            if (user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User FindById(int userId)
        {
            return db.Users.Find(userId);
        }

        public static bool UpdateUser(User currUser)
        {
            if (currUser != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}