using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        string isbn;
        string title;
        string type;
        string method;
        decimal price;
        int quantity;
        decimal cost;

        public String ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public String Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public String Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
            
        }

        public override String ToString()
        {
            return method;
        }


    }

    
}
