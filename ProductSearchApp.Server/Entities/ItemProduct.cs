namespace ProductSearchApp.Server.Entities
{
    public class ItemProduct : Entity
    {
        public string Name { get; set; } = string.Empty;
        public double Cost { get; set; }

        public ItemProduct()
        {
            
        }
        public ItemProduct(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
