using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT123P___Course_Management_Systemm
{
    public class User
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract void AccessPortal();
        public abstract void DisplayInfo();
    }
}