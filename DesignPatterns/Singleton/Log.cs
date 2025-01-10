namespace DesignPatterns.Singleton
{
    public class Log
    {
        private static Log _instance = new Log();
        private string _path = "log.txt";
        private static object _protect = new object();
        public static Log Instance
        {
            get
            {
                return _instance;
            }
        }

        private Log() { }

        public async Task Save(string message)
        {
            await File.AppendAllTextAsync(_path, message + Environment.NewLine);
        }

    }
}
