using Baja.Silver.Domain;
using Baja.Silver.Domain.Catalog;
using Baja.Silver.Domain.Orders;

namespace Baja.Silver.Tests;

[TestClass]
public class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        // Arrange
        var rating = new Rating(1, 1, "Mike", "Great fit!");

        // Act (empty)

        //Assert
        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }
}