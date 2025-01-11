namespace DesignPatterns.Builder
{
    public interface IBuilder
    {
        public void Reset();
        public void SetAlcohol(decimal alcohol);
        public void SetMilk(int milk);
        public void SetWater(int water);
        public void Mix();
        public void Rest(int time);
        public void AddIngredients(string ingredients);
    }
}
