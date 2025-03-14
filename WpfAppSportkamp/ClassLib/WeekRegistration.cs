using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class WeekRegistration
    {
        public int Amount { get; set; }
        public double Price { get; set; }

        public WeekRegistration()
        {
            
        }

        public WeekRegistration(int amount, double price)
        {
            Amount = amount;
            Price = price;
        }

        public WeekRegistration[] WeekOverview(int amount)
        {
            throw new Exception();
        }
    }
}
