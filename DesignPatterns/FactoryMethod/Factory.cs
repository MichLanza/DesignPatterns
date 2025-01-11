namespace DesignPatterns.FactoryMethod
{
    //Creator
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    //Creador concreto
    public class SaleStoreFactory : SaleFactory
    {
        private decimal _extra;

        public SaleStoreFactory(decimal extra)
        {
            _extra = extra;
        }

        public override ISale GetSale()
        {
            return new SaleStore(_extra);
        }
    }


    //Producto
    public interface ISale
    {
        public void Sell(decimal total);
    }


    //Producto Concreto
    public class SaleStore : ISale
    {
        private decimal _extra;
        public SaleStore(decimal extra)
        {
            _extra = extra;
        }
        public void Sell(decimal total)
        {
            Console.WriteLine($"Venta en tienda de {total + _extra}");
        }
    }




}
