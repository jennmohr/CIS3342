using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Contact
    {

        string studentID;
        string name;
        string phone;
        string address;
        string campus;

        public String StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public String Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public String Campus
        {
            get
            {
                return campus;
            }
            set
            {
                campus = value;
            }
        }

        
    }
}
