using DesignPattern.DependencyInjection;
using DesignPattern.FactoryPattern;

namespace DesignPattern
{
    class Program
    {
        static void Main(string [] args)
        {
            //FACTORY
            /*
            SaleFactory storeSaleFactory = new StoreSaleFactory(10);
            SaleFactory internetSaleFactory = new InternetSaleFactory(2);


            ISale sale1 = storeSaleFactory.GetSale();
            sale1.Sell(15);
            

            ISale sale2 = internetSaleFactory.GetSale();
            sale2.Sell(15);
            */

            //INYECCION DE DEPENDENCIA
            var beer = new Beer("Pikantus", "Erdinger");
            var drinkWithBeer = new DrinkWithBeer(10,1,beer);
            drinkWithBeer.Build();
           

        }
    }
}