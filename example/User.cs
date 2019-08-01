using System;
using System.Collections.Generic;
using System.Numerics;

namespace example
{
    public class User
    {
        public BigInteger Id { get; set; }
        public Dictionary<BigInteger, BigInteger> W { get; set; }
        public BigInteger Share { get; set; }

        public TimeSpan ExecutionTime { get; set; }
    }
}
