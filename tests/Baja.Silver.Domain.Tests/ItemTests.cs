using Baja.Silver.Domain;
using Baja.Silver.Domain.Catalog;
using Baja.Silver.Domain.Orders;

namespace Baja.Silver.Tests;

[TestClass]
public class ItemTests 
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m);
        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }

    [TestMethod]
    public void Can_Create_Add_Rating()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m);
        var rating = new Rating(1, 1, "Mike", "Great fit!");
        item.AddRating(rating);
        Assert.AreEqual(rating, item.Ratings[0]);
    }
}