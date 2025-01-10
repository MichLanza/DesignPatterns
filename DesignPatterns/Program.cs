using DesignPatterns.Singleton;
using DesignPatterns.FactoryMethod;
using DesignPatterns.DependencyInjection;

//Singleton
var singleton = SingletonExample.Instance;
var log = Log.Instance;
await log.Save("Hola Mundo");

//FactoryMethod
SaleFactory saleStoreFactory = new SaleStoreFactory(10);
ISale sale = saleStoreFactory.GetSale();
sale.Sell(15);

//DependencyInjection

var videoGame = new VideoGame("Hollow Knight" , "Metroidvania");
var playing = new PlayVideoGame(videoGame, "PC");
playing.Play();






