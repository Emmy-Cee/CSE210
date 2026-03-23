public class Order
{
    private List<Product> _products;
    private Customer _Customer;

    public Order(Customer Customer)
    {
        _Customer = Customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalPrice();
        }

        // Add shipping
        double shippingCost;
        if (_Customer.IsInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += $"Product: {p.GetName()}, ID: {p.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_Customer.GetName()}\n{_Customer.GetAddressString()}";
    }
}