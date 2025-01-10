
using DesignPatterns.FactoryMethod;
using DesignPatterns.Singleton;


var singleton = SingletonExample.Instance;
var log = Log.Instance;

await log.Save("Hola Mundo");


SaleFactory saleStoreFactory = new SaleStoreFactory(10);

ISale sale = saleStoreFactory.GetSale();

sale.Sell(15);


