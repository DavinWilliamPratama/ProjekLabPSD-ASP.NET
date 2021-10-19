using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Factory
{
    public class UserFactory
    {
        public static User Create(string name, string username, string password, int role)
        {
            User newUser = new User();
            
            newUser.Name = name;
            newUser.Username = username;
            newUser.Password = password;
            newUser.RoleId = role;
            return newUser;
        }
    }
}