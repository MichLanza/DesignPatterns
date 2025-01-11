﻿using DesignPatterns.Singleton;
using DesignPatterns.FactoryMethod;
using DesignPatterns.DependencyInjection;
using DesignPatterns.Models;
using DesignPatterns.Repository;

//Singleton
var singleton = SingletonExample.Instance;
var log = Log.Instance;
await log.Save("Hola Mundo");

//FactoryMethod
SaleFactory saleStoreFactory = new SaleStoreFactory(10);
ISale sale = saleStoreFactory.GetSale();
sale.Sell(15);

//DependencyInjection
var videoGameDI = new VideoGameDI("Hollow Knight", "Metroidvania");
var playing = new PlayVideoGame(videoGameDI, "PC");
playing.Play();

//EntityFramework
using var contextDb = new VideoGameAppContext();
var list = contextDb.Videogames.ToList();
foreach (var vg in list)
    Console.WriteLine(vg.Nombre);

//Repository
var repository = new VideoGameRepository(contextDb);
var videoGame = new Videogame { Nombre = "Hollow Knight", Genero = "Metroidvania" };
repository.Add(videoGame);
repository.Save();
var vgs = repository.Get();
foreach (var vg in vgs)
    Console.WriteLine(vg.Nombre);

//Generic Repository
var genericRepo = new Repository<Videogame>(contextDb);
var newVideoGame = new Videogame { Nombre = "Stardew Valley", Genero = "Simulación" };
genericRepo.Add(newVideoGame);
genericRepo.Save();
var list2 = genericRepo.Get();

genericRepo.Delete(list2.FirstOrDefault(v => v.Nombre == "Hollow Knight").Id);
genericRepo.Save();
foreach (var vg in list2)
    Console.WriteLine(vg.Nombre);
var companyRepo = new Repository<Company>(contextDb);
var newCompany = new Company { Id = 7, Name = "Konami" };
companyRepo.Add(newCompany);
companyRepo.Save();
foreach (var company in companyRepo.Get())
{
    Console.WriteLine(company.Name);
}


//UnitOfWork


