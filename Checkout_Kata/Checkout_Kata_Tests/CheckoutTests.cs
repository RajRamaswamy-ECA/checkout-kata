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
        public void ScanOneItem()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            var totalPrice = checkout.GetTotalPrice();
            Assert.Greater(totalPrice, 0);
        }

        [Test]
        public void ScanItemsWithOffer()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("B");
            checkout.Scan("B");
            var totalPrice = checkout.GetTotalPrice();
            Assert.Greater(totalPrice, 0);
        }
    }
}