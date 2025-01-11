namespace DesignPatterns.Builder
{
    public class BarmanDirector
    {
        private IBuilder _builder;
        public BarmanDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PrepareLimonade()
        {
            _builder.AddIngredients("limon");
            _builder.AddIngredients("azucar");
            _builder.SetWater(250);
            _builder.Mix();
        }
    }
}
