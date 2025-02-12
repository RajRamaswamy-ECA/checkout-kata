using Checkout_Kata;

namespace Checkout_Kata_Tests
{
    public class CheckoutTests
    {        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Scan_OneItem()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            var totalcheckoutItems = checkout.TotalCheckoutItems;
            Assert.AreEqual(totalcheckoutItems, 1);
        }

        [Test]
        public void Scan_ItemsWithOffer()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            var totalcheckoutItems = checkout.TotalCheckoutItems;
            Assert.AreEqual(totalcheckoutItems, 4);
        }

        [Test]
        public void Scan_ItemsInRandomOrder()
        {
            var checkout = new Checkout();
            checkout.Scan("A"); //50 or 3 for 130
            checkout.Scan("B"); //30 or 2 for 45
            checkout.Scan("A");
            checkout.Scan("D"); //15
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C"); //20
            var totalcheckoutItems = checkout.TotalCheckoutItems;
            Assert.AreEqual(totalcheckoutItems, 7);
        }

        [Test]
        public void Scan_InvalidItem()
        {
            var checkout = new Checkout();
            var exception = Assert.Throws<Exception>(() => checkout.Scan("E"));
            Assert.AreEqual("Item Not Found", exception.Message);
        }

        [Test]
        public void GetTotalPrice_OneItem()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            var totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(totalPrice, 50);
        }

        [Test]
        public void GetTotalPrice_ItemsWithOffer()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            var totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(totalPrice, 125);
        }

        [Test]
        public void GetTotalPrice_ItemsInRandomOrder()
        {
            var checkout = new Checkout();
            checkout.Scan("A"); //50 or 3 for 130
            checkout.Scan("B"); //30 or 2 for 45
            checkout.Scan("A");
            checkout.Scan("D"); //15
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("C"); //20
            var totalPrice = checkout.GetTotalPrice();
            Assert.AreEqual(totalPrice, 210);
        }
    }
}