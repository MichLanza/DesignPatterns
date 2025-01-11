namespace DesignPatterns.Strategy
{
    public class CarStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy un carro y me estoy moviendo por la carretera");
        }
    }
}
