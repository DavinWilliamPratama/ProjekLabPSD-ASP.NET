using ProjekLab.Factory;
using ProjekLab.Model;
using ProjekLab.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Handlers
{
    public class UserHandler
    {

        public static User Login(String username, string password)
        {
            return UserRepository.GetUser(username, password);
        }

        public static User InsertNewUser(string name, string username, string password, string roles)
        {
            Role userRole = RoleRepository.GetRole(roles);
            User user = UserFactory.Create(name, username, password, userRole.Id);

            return UserRepository.InsertUser(user);
        }

        public static User GetUser(string username, string password)
        {
            return UserRepository.GetUser(username, password);
        }

        public static User GetUserById(int userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public static bool UpdateUser(int userId, string name, string password)
        {
            User currUser = UserRepository.FindById(userId);

            if (currUser == null)
            {
                return false;
            }

            currUser.Name = name;
            currUser.Password = password;


            return UserRepository.UpdateUser(currUser);

        }

        public static bool UpdateUserWithoutPassword(int userId, string name)
        {
            User currUser = UserRepository.FindById(userId);

            if (currUser == null)
            {
                return false;
            }

            currUser.Name = name;


            return UserRepository.UpdateUser(currUser);

        }


        public static bool MatchPassword(int userId, string password)
        {
            return UserRepository.MatchPassword(userId, password);
        }
    }
}