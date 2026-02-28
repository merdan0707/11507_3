namespace Order;

class Program
{
    static void Main(string[] args)
    {
        Order<decimal> order = new Order<decimal>(){Id = 100, Price = 2000};
        Order<double> order_2 = new Order<double>(){Id = 101, Price = 100};

        
        
        var car = OrderBuilder<decimal>.StartOrder()
            .SetId(1804)
            .SetBasePrice(1000000)
            .Build();

        DiscountHandler<decimal> discountHandler = new DiscountHandler<decimal>(50000); 
        TaxHandler<decimal> taxHandler = new TaxHandler<decimal>(1.2m);
        ValidationHandler<decimal>  validationHandler = new ValidationHandler<decimal>();
        
        discountHandler.SetNext(taxHandler);
        taxHandler.SetNext(validationHandler);
        
        OrderProcessor<decimal>.Process(car, discountHandler); 
    }
}