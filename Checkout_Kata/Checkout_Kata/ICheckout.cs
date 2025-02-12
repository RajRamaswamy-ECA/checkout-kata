namespace Checkout_Kata
{
    public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice();

        int TotalCheckoutItems { get;  }

    }
}
