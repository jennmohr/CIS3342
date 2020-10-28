using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewClasses
{
    public class Review
    {
        string restName;
        string comment;
        int service;
        int quality;
        int price;
        int atmos;
        string userID;

        public Review(string restName, string comment, int service, int quality, int price, int atmos, string userID)
        {
            this.restName = restName;
            this.comment = comment;
            this.service = service;
            this.quality = quality;
            this.price = price;
            this.atmos = atmos;
            this.userID = userID;
        }

        public string getRestName()
        {
            return this.restName;
        }

        public string getComment()
        {
            return this.comment;
        }

        public int getService()
        {
            return this.service;
        }

        public int getQuality()
        {
            return this.quality;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getAtmos()
        {
            return this.atmos;
        }

        public string getUser()
        {
            return this.userID;
        }
    }
}
