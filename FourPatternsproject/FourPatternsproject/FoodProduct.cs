namespace FourPatternsproject
{
    internal class FoodProduct
    {
        public string name, description;
        public double price;
        public int availableInStock;

        public FoodProduct(string name, string description, double price, int availableInStock)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.availableInStock = availableInStock;
        }
    }
}