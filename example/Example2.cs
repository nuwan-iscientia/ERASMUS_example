using System;
using System.Numerics;
using System.Threading.Tasks;

namespace example
{
    public class Example2 : Example
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

            Console.WriteLine("Enter to:"); 
            string to = Console.ReadLine();
            Console.WriteLine("Enter my Private Key:");
            string privateKey = Console.ReadLine();

            Console.WriteLine("Enter message:");
            string message = Console.ReadLine();
            var encryptedMessage =  await Encrypt(scheme.Name, BigInteger.Parse(to), BigInteger.Parse(privateKey), message);

            Console.WriteLine(encryptedMessage);


            Console.WriteLine("Enter from:");
            string from = Console.ReadLine();
            Console.WriteLine("Enter my Private Key:");
            privateKey = Console.ReadLine();

            Console.WriteLine("Enter message:");
            message = Console.ReadLine();
            var decryptedMessage = await Decrypt(scheme.Name, BigInteger.Parse(from), BigInteger.Parse(privateKey), message);

            Console.WriteLine(decryptedMessage);


        }
    }
}