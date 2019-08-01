using System.Numerics;

namespace example
{
    public class AddSchemeRequest
    {
        public string Name { get; set; }
        public BigInteger T { get; set; }
        public BigInteger P { get; set; }
        public BigInteger Q { get; set; }
        public BigInteger G { get; set; }
    }

    public class Scheme
    {
        public string Name { get; set; }
        public BigInteger T { get; set; }
        public BigInteger P { get; set; }
        public BigInteger Q { get; set; }
        public BigInteger G { get; set; }
    }
}
