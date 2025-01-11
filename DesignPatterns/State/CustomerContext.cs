namespace DesignPatterns.State
{
    public class CustomerContext
    {
        private IState _state;

        private decimal _balance;

        public decimal Balance
        { 
            get => _balance;
            set => _balance = value;
        }

        public CustomerContext()
        {
            _state = new NewCustomerState();
        }

        public void SetState(IState state) => _state = state;

        public IState GetState() => _state;

        public void Request(decimal amount) => _state.Action(this, amount);

        public void Discount(decimal amount) => Balance -= amount;

    }
}
