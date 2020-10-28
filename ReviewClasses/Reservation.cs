using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewClasses
{
    public class Reservation
    {
        DateTime resTime;
        int partyAmount;
        string name;
        string restName;

        public Reservation(DateTime resTime, int partyAmount, string name, string restName)
        {
            this.resTime = resTime;
            this.partyAmount = partyAmount;
            this.name = name;
            this.restName = restName;
        }

        public DateTime getResTime()
        {
            return this.resTime;
        }

        public int getParty()
        {
            return this.partyAmount;
        }

        public string getName()
        {
            return name;
        }

        public string getRestName()
        {
            return restName;
        }
    }
}
