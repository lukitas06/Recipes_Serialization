using NUnit.Framework;
using Recipies;
using System.Globalization;
using System.Text.Json;

namespace LibraryTests
{
    [TestFixture]
    [SetCulture("en-US")]
    public class ProductTests
    {
        private static string description = "Test Product";
        private static double unitCost = 9.99;
        private static string expected = $@"{{""Description"":""{description}"",""UnitCost"":{unitCost}}}";
        private static string json = $@"{{""Description"":""{description}"",""UnitCost"":{unitCost}}}";

        [Test]
        public void SerializeProductTest()
        {

            IJsonConvertible Product = new Product(description, unitCost);
            string actual = Product.ConvertToJson();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [SetCulture("en-US")]
        public void DeserializeProductTest()
        {
            Product product = new Product(json);
            //Product Productdeser= JsonSerializer.Deserialize<Product>(json);


            Assert.AreEqual(description, product.Description);
            Assert.AreEqual(unitCost, product.UnitCost);
        }
    }
}