namespace ChainResponsibilityPattern
{
    public class Customer
    {
        public CustomerTypes CustomerType { get; set; }
    }

    public enum CustomerTypes
    {
        VIP,
        Regular,
        New,
        None
    }
}