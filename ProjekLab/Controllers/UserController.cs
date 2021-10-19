using ProjekLab.Handlers;
using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Views
{
    public class UserController
    {
        public static string CheckName(string name)
        {
            string response = "";

            if (name == "")
            {
                response = "Name must be filled!";
            }
            else if (name.Length < 1 || name.Length > 30)
            {

                response = "Name must be at least 1 and 30 characters!";
            }
            else
            {
                foreach (char ch in name)
                {
                    if (!Char.IsLetter(ch) && !char.IsWhiteSpace(ch))
                    {
                        response = "Name must be alphabet";
                    }
                }
            }

            return response;
        }

        public static string CheckUsername(string username)
        {
            string response = "";

            if (username == "")
            {
                response = "Username must be filled!";
            }
            else if (username.Length < 6 || username.Length > 20)
            {

                response = "Username must be at least 6 and 20 characters!";
            }
            else
            {
                foreach (char ch in username)
                {
                    if(!Char.IsLetterOrDigit(ch) && !Char.IsWhiteSpace(ch) && ch != '_')
                    {
                        response = "Username must alphanumeric with space, or underscore!";
                    }
                }
            }
            return response;
        }

        public static string CheckPassword(string password, string confirmpassword)
        {
            string response = "";
            if(password == "")
            {
                return "Password must be filled!";
            }

            if(password.Length < 6 || password.Length > 20)
            {
                return "Password must be between 6 and 20 characters!";
            }

            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    response = "Password must be alphanumeric!";
                }
            }
            if (password != confirmpassword)
            {
                return "Confirm password must be the same with password!";
            }
            return response;
        }

        public static string CheckRegister(string name, string username, string password, string confirmpassword, string roles)
        {
            string response = "";

            response = CheckName(name);

            if (response == "")
            {
                response = CheckUsername(username);
                if (response == "")
                {
                    if (CheckPassword(password, confirmpassword) != "")
                    {
                        response = CheckPassword(password, confirmpassword);
                    }
                    else
                    {
                        if (roles == "")
                        {
                            response = "Roles must be chosen";
                        }
                        else
                        {
                            if (UserHandler.InsertNewUser(name, username, password, roles) != null)
                            {
                                response = "";
                            }
                            else
                            {
                                response = "Failed to register!";
                            }
                        }
                    }
                }
            }
            return response;
        }

        public static string CheckUpdateField(int userId, string name, string oldpassword ,string password, string confirmpassword)
        {
            string response = CheckName(name);
            if(response != "")
            {
                return response;
            }
            else
            {
                response = CheckPassword(password, confirmpassword);
                if(response != "")
                {
                    return response;
                }
                else
                {
                    if(MatchPassword(userId, oldpassword) == "")
                    {
                        if(UserHandler.UpdateUser(userId, name, password) == false)
                        {
                            response = "Failed update profile";
                        }
                    }
                    else
                    {
                        response = "No Password match!";
                    }
                }
            }
            return response;
        }

        public static string CheckUpdateFieldWithoutPass(int userId, string name)
        {
            string response = CheckName(name);
            if (response != "")
            {
                return response;
            }
            else
            {
                if (UserHandler.UpdateUserWithoutPassword(userId, name) == false)
                {
                    response = "Failed update profile";
                }
             }
            
            return response;
        }

        public static string CheckLogin(string username, string password)
        {
            string response = "";

            User currUser = UserHandler.Login(username, password);

            if (currUser == null)
            {
                response = "User not found";
            }
            return response;
        }

        public static string MatchPassword(int userId, string password)
        {
            string response = "";
            if (UserHandler.MatchPassword(userId, password) == false)
            {
                response = "Wrong Password!";
            }
            return response;
        }

        public static User GetUser(string username, string password)
        {
            return UserHandler.GetUser(username, password);
        }

        public static string ShowUserDetail(int userId, string lblText)
        {
            if (lblText.Equals("txtUsername"))
            {
                return "Username: " + UserHandler.GetUserById(userId).Username;
            }
            else if (lblText.Equals("txtName"))
            {
                return "Name: " + UserHandler.GetUserById(userId).Name;
            }
            else if (lblText.Equals("txtRole"))
            {
                if (UserHandler.GetUserById(userId).RoleId == 1)
                {
                    return "Role: Seller";
                }
                else
                {
                    return "Role: Member";
                }
            }
            else
            {
                return "";
            }
        }
    }
}