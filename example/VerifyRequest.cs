using System;
using System.Collections.Generic;
using System.Numerics;

namespace example
{
    public class VerifyResponse
    {
        public bool Verified { get; set; }
        public BigInteger PrivateKey { get; set; }
        public BigInteger PublicKey { get; set; }
        public TimeSpan ExecutionTime { get; set; }
    }

    public class VerifyRequest
    {
        public BigInteger Id { get; set; }
        public BigInteger T { get; set; }

        public BigInteger P { get; set; }

        public BigInteger Q { get; set; }

        public BigInteger G { get; set; }

        public Dictionary<BigInteger, BigInteger> W { get; set; }

        public BigInteger Share { get; set; }
    }
}
