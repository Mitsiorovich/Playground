namespace ISPExample
{
    public interface IBasicFeatures
    {
        void Print(string content);
    }

    public interface IAdvancedFeatures // could be two interfaces but enough to be ISP compliant
    {
        void Scan(string content);
        void Fax(string content);
    }

    public class OldPrinter : IBasicFeatures
    {
        public void Print(string content) => Console.WriteLine("Printing: " + content);
    }

    public class ModernPrinter : IAdvancedFeatures, IBasicFeatures
    {
        public void Print(string content) => Console.WriteLine("Printing: " + content);
        public void Scan(string content) => Console.WriteLine("Scanning: " + content);
        public void Fax(string content) => Console.WriteLine("Faxing: " + content);
    }
}
