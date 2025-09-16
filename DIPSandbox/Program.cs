namespace DIPTask
{
    public interface IProcessor
    {
        public void Pay(decimal amount);
    }
    public class CreditCardProcessor: IProcessor
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment: {amount}");
        }
    }

    public class PayPalProcessor : IProcessor 
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment: {amount}");
        }
    }

    public class PaymentService
    {
        private readonly IProcessor _processor;
        public PaymentService(IProcessor processor)
        {
            _processor = processor;
        }

        public void MakePayment(decimal amount)
        {
            _processor.Pay(amount); 
        }
    }
}
