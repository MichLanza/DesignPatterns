namespace Tools.Earn
{
    public class LocalEart : IEarn
    {
        private decimal _percentage;

        public LocalEart(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal Earn(decimal amount)
        {
            return amount * _percentage;
        }
    }
}
