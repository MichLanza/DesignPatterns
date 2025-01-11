namespace DesignPatterns.State
{
    public class NewCustomerState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            Console.Write($"Se le pone dinero a su saldo: {amount}");

            customerContext.Balance = amount;
            customerContext.SetState(new NotDebtorState());
        }
    }
}
