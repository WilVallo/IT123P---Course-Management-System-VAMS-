using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT123P___Course_Management_Systemm
{
    public class Administrator : User
    {
        public string Permissions { get; set; }

        public void ManageUserAccounts()
        {
            System.Diagnostics.Debug.WriteLine("Managing user accounts...");
        }

        public override void AccessPortal()
        {
            System.Diagnostics.Debug.WriteLine("Accessing admin portal...");
        }

        public override void DisplayInfo()
        {
            System.Diagnostics.Debug.WriteLine($"Admin: {FirstName} {LastName}, Permissions: {Permissions}");
        }
    }
}