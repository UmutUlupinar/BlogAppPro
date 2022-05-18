﻿using BlogAppPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppPro.Entities.Concrete
{
    public class User:EntityBase,IEntity
    {
        public  string FirstName{ get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public string UserName { get; set; }

        public int RoleID { get; set; }

        public Role Role { get; set; }

        public string ProfileImage { get; set; }

        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
        
        


    }
    
}
