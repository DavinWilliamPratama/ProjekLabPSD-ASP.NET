using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjekLab.Repository
{
    
    public class RoleRepository
    {
        private static MyDatabaseEntities1 db = new MyDatabaseEntities1();

        public static Role GetRole(string roles)
        {
            Role role = (from x in db.Roles where x.Name == roles select x).FirstOrDefault();

            return role;
        }
    }
}