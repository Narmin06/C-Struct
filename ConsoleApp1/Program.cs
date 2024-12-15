Article article1 = new Article
{
    ProductCode = "PR01",
    ProductName = "T-shirt",
    Price = 30.7m,
    Type = ArticleType.CLOTHING
};

Article article2 = new Article
{
    ProductCode = "PR02",
    ProductName = "Shoes",
    Price = 70.0m,
    Type = ArticleType.SHOES
};

Client client1 = new Client
{
    ClientCode = "CL01",
    FullName = "Narmin Alishova",
    Address = "Badamdar",
    Telephone = "050-839-33-11",
    NumberOfOrders = 3,
    TotalAmount = 200.0m,
    Type = ClientType.VIP
};

RequestItem requestItem1 = new RequestItem
{
    Commodity = article1,
    NumberOfCommodityUnits = 2
};

RequestItem requestItem2 = new RequestItem
{
    Commodity = article2,
    NumberOfCommodityUnits = 1 
};

Request request1 = new Request
{
    OrderCode = "OR01",
    Client = client1,
    OrderDate = DateTime.Now,
    Products = new List<RequestItem> { requestItem1, requestItem2 }
};

Console.WriteLine($"Sifariş Kodu: {request1.OrderCode}");
Console.WriteLine($"Müşteri: {request1.Client.FullName}");
Console.WriteLine($"Sifariş Tarixi: {request1.OrderDate}");
Console.WriteLine($"Sifarişin Qiymeti: {request1.OrderPrice}");

public struct Article   
{
    public string ProductCode;
    public string ProductName;
    public decimal Price;
    public ArticleType Type;
}

public struct Client   
{
    public string ClientCode;
    public string FullName;
    public string Address;
    public string Telephone;
    public int NumberOfOrders;
    public decimal TotalAmount;    
    public ClientType Type;
}

public struct RequestItem
{
    public Article Commodity;
    public int NumberOfCommodityUnits;
}

public struct Request
{
    public string OrderCode;
    public Client Client;
    public DateTime OrderDate;
    public List<RequestItem> Products;
    public decimal OrderPrice {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Products)
            {
                totalPrice += item.Commodity.Price * item.NumberOfCommodityUnits;
            }
            return totalPrice;
        }
    }
}

public enum ArticleType
{
    BOOKS,
    FOOD,
    CLOTHING,
    SHOES
}

public enum ClientType
{
    Regular,  
    VIP      
}

public enum PayType
{
    Cash,
    CreditCard
}