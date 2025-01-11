namespace DesignPatterns.State
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Balance)
            {
                Console.WriteLine($"Solicitud permitida: {amount}, su balance es: {customerContext.Balance}");
                if(customerContext.Balance - amount <= 0)                
                    customerContext.SetState(new DebtorState());                               
            }
            else
            {
                Console.WriteLine($"Solicitud no permitida: {amount}, su balance es: {customerContext.Balance}");
            }
        }
    }
}
