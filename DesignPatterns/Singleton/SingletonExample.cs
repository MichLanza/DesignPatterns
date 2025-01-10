namespace DesignPatterns.Singleton
{
    public class SingletonExample
    {
        private readonly static SingletonExample _instance = new SingletonExample();

        public static SingletonExample Instance
        {
            get
            {
                return _instance;
            }
        }

        private SingletonExample() { }
    }
}
