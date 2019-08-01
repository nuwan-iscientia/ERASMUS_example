using System.Numerics;
using System.Threading.Tasks;

namespace example
{
    public class Example1 : Example
    {
        public override async Task Run()
        {
            // 1. Ceate a Security Scheme 
            await CreateSecurityScheme("default");
            // 2. Get Security Scheme  
            var scheme = await GetSecurityScheme("default");
            // 3 Join Security Scheme User A 
            var userA = await JoinSecurityScheme(scheme, new BigInteger(11));
            // 4 Verify Share for User A
            await VerifyShare(scheme, userA);
            // 5 Join Security Scheme User B
            var userB = await JoinSecurityScheme(scheme, new BigInteger(12));
            // 6 Verify Share for User B
            await VerifyShare(scheme, userB);
        }
    }
}