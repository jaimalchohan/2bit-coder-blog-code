namespace LuceneDemo.Service.Contracts
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Department Department { get; set; }
    }
}
