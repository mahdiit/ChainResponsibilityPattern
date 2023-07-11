namespace ChainResponsibilityPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var chain = new VIPHandler();
            chain
                .Next(new RegularHandler())
                .Next(new NewHandler());

            var result = chain.Execute(new Customer() { CustomerType = CustomerTypes.VIP }, 1000);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}