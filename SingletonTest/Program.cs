namespace SingletonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejemplo de Singleton Multihilo");

            Parallel.Invoke(
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance(),
                () => PrintSingletonInstance()
                );
            Console.ReadKey();
        }

        static void PrintSingletonInstance()
        {
            Singleton singleton = Singleton.GetInstance();
            Console.WriteLine($"La instancia del Singleton es: {singleton.GetHashCode()}");
        }
    }

    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static object syncRoot = new Object();

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new Singleton();
                }
            }

            return instance;
        }
    }
}
