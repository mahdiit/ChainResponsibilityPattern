using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern
{
    public class SimpleCalculate
    {
        public static decimal Calculate(Customer customer, decimal orderTotal)
        {
            switch (customer.CustomerType)
            {
                case CustomerTypes.VIP:
                    return orderTotal * 0.08m;
                case CustomerTypes.Regular:
                    return orderTotal * 0.09m;
                case CustomerTypes.New:
                    return orderTotal * 0.095m;
                default:
                    return orderTotal;
            }
        }
    }
}
