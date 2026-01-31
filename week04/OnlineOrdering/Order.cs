using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void NewProduct(Product product)
    {
        _products.Add(product);
    }
        
    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }
        if (_customer.IsUSA())
        {
            total +=5;
        }
        else
        {
            total +=35;
        }
        return total;
    }

    public string GetPacking()
    {
        string result = "";
        foreach (Product p in _products)
        {
            result += p.GetPackingLabel() + "\n";
        }
        return result;
    }

    public string GetShipping()
    {
        return _customer.GetShippingLabel();
    } 
}
     