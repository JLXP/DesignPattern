using DesignPattern.Data;
using DesignPattern.Models;
using DesignPattern.UnitOfWorkPattern;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
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
            /*var beer = new Beer("Pikantus", "Erdinger");
            var drinkWithBeer = new DrinkWithBeer(10,1,beer);
            drinkWithBeer.Build();*/

            //REPOSITORY

            /*using (var context = new AppDbContext())
            {
                var lst = context.Beers.ToList();
                foreach(var beer in lst)
                {
                    Console.WriteLine(beer.Name);
                }
            }*/

            /*using (var context = new AppDbContext())
            {
                var beerRepository = new BeerRepository(context);
                var beer = new Beer();
                beer.Name = "Corona";
                beer.Style = "Pilsner";
                beerRepository.Add(beer);
                beerRepository.Save();

                foreach(var b in beerRepository.Get())
                {
                    Console.WriteLine(b.Name);
                }
            }*/

            /*using (var context = new AppDbContext())
            {
                var beerRepository = new Repository<Beer>(context);
                var beer = new Beer() { Name = "Fuller", Style = "Strong Ale" };
                beerRepository.Add(beer);
                beerRepository.Save();

                foreach (var b in beerRepository.Get())
                {
                    Console.WriteLine($"{b.BeerId} {b.Name}");
                }


            }*/
            
            //UNIT OF WORK
            using (var context = new AppDbContext())
            {
                var unitOfWork = new UnitOfWork(context);
                var beers = unitOfWork.Beers;
                var beer = new Beer()
                {
                    Name = "Fuller",
                    Style = "Porter"
                };
                beers.Add(beer);

                var brands = unitOfWork.Brands;
                var brand = new Brand()
                {
                    Name = "Fuller"
                };

                brands.Add(brand);

                unitOfWork.Save();


            }


        }
    }
}