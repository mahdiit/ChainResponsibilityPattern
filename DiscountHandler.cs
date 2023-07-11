using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsibilityPattern
{
    public class HandlerResult<TType>
    {
        public static HandlerResult<TType> Factory()
        {
            return new HandlerResult<TType>();
        }

        public HandlerResult()
        {

        }

        public HandlerResult(TType value)
        {
            Value = value;
        }

        private TType _value;
        public TType Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                IsHandle = true;
            }
        }
        public bool IsHandle { get; private set; }
    }

    public abstract class DiscountHandler
    {
        protected DiscountHandler _nextHandler;
        protected abstract HandlerResult<decimal> Calculate(Customer customer, decimal amount);

        public DiscountHandler Next(DiscountHandler discountHandler)
        {
            _nextHandler = discountHandler;
            return _nextHandler;
        }

        public virtual decimal Execute(Customer customer, decimal amount)
        {
            Console.WriteLine(this.GetType().ToString());

            var result = Calculate(customer, amount);
            if (result.IsHandle) { return result.Value; }

            return _nextHandler?.Execute(customer, amount) ?? amount;
        }
    }

    public class VIPHandler : DiscountHandler
    {
        protected override HandlerResult<decimal> Calculate(Customer customer, decimal amount)
        {
            if (customer.CustomerType == CustomerTypes.VIP)
            {
                return new HandlerResult<decimal>(amount * 0.08m);
            }

            return HandlerResult<decimal>.Factory();
        }
    }

    public class RegularHandler : DiscountHandler
    {
        protected override HandlerResult<decimal> Calculate(Customer customer, decimal amount)
        {
            if (customer.CustomerType == CustomerTypes.Regular)
            {
                return new HandlerResult<decimal>(amount * 0.09m);
            }

            return HandlerResult<decimal>.Factory();
        }
    }

    public class NewHandler : DiscountHandler
    {
        protected override HandlerResult<decimal> Calculate(Customer customer, decimal amount)
        {
            if (customer.CustomerType == CustomerTypes.New)
            {
                return new HandlerResult<decimal>(amount * 0.085m);
            }

            return HandlerResult<decimal>.Factory();
        }
    }
}
