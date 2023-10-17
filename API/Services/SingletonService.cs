namespace API.Services
{
    public class SingletonService
    {
        public Guid ID { get; init; }
        public SingletonService()
        {
            ID = Guid.NewGuid();
            Console.WriteLine("Singlton service yaratildi");
        }
    }
}
