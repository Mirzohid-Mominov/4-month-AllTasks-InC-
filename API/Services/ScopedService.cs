namespace API.Services
{
    public class ScopedService
    {
        public Guid ID { get; init; }
        public ScopedService()
        {
            ID = Guid.NewGuid();
            Console.WriteLine("scoped service yaratildi");
        }
    }
}
