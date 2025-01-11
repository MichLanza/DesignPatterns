namespace DesignPatterns.State
{
    public class DebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.WriteLine($"Solicitud no permitida");
        }
    }
}
