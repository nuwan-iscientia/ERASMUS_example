using System;
using System.Numerics;
using System.Threading.Tasks;

namespace example
{
    public class Example
    {
        private static string url = "https://localhost:44378";

        private static readonly string Action_AddScheme = $"{url}/api/Schemes";
        private static readonly string Action_GetScheme = $"{url}/api/Schemes/";
        private static readonly string Action_JoinScheme = $"{url}/api/Dealer/";
        private static readonly string Action_VerifyShare = $"{url}/api/Verify/";
        private static readonly string Action_Encrypt = $"{url}/api/message/encrypt/";
        private static readonly string Action_Decrypt = $"{url}/api/message/decrypt/";
        

        private ApiClient _apiClient;

        public Example()
        {
            _apiClient = new ApiClient(new Uri(url));
        }

        public virtual async Task Run()
        {
        }

        protected async Task<string> Encrypt(string schemeName, BigInteger toUserId, BigInteger myPrivateKey, string msg)
        {
            return await _apiClient.Get($"{Action_Encrypt}{schemeName}/{myPrivateKey}/{toUserId}?message={msg}");
        }

        protected async Task<string> Decrypt(string schemeName, BigInteger fromUserId, BigInteger myPrivateKey, string msg)
        {
            return await _apiClient.GetAsync<string>($"{Action_Decrypt}{schemeName}/{fromUserId}/{myPrivateKey}?message={msg}");
        }

        protected async Task VerifyShare(Scheme scheme, User user)
        {
            var verifyResponse = await _apiClient.PostAsync<VerifyResponse, VerifyRequest>($"{Action_VerifyShare}",
                new VerifyRequest
                {
                    Id = user.Id,
                    G = scheme.G,
                    P = scheme.P,
                    Q = scheme.Q,
                    T = scheme.T,
                    W = user.W,
                    Share = user.Share
                });

            if (verifyResponse.Verified)
            {
                Console.WriteLine($"User {user.Id} Share verified");
                Console.WriteLine($"Public Key [{user.Id}] = {verifyResponse.PublicKey}");
                Console.WriteLine($"Private Key [{user.Id}]  = {verifyResponse.PrivateKey}");
                Console.WriteLine($"ExecutionTime = {verifyResponse.ExecutionTime.TotalMilliseconds}");
            }
            else
            {
                Console.WriteLine($"User {user.Id} invalid share ");
            }
        }
        protected async Task<User> JoinSecurityScheme(Scheme scheme, BigInteger id)
        {
            var user =  await _apiClient.GetAsync<User>($"{Action_JoinScheme}{scheme.Name}/{id}");

            Console.WriteLine($"User {id} Joined Security Scheme {scheme.Name}:");
            Console.WriteLine($"Share = {user.Share}");
            Console.WriteLine($"ExecutionTime = {user.ExecutionTime.TotalMilliseconds}");
            for (var i = 0; i < scheme.T; i++)
            {
                Console.WriteLine($"W[{i}] = {user.W[i]}");
            }
            return user;
        }

        protected async Task CreateSecurityScheme(string schemeName)
        {
            var schemeRequest = new AddSchemeRequest
            {
                Name = schemeName,
                G = new BigInteger(33),
                T = new BigInteger(3),
                P = new BigInteger(71),
                Q = new BigInteger(70),
            };
            await _apiClient.PostAsync<AddSchemeRequest, AddSchemeRequest>(Action_AddScheme, schemeRequest);
        }

        protected async Task<Scheme> GetSecurityScheme(string name)
        {
            var scheme = await _apiClient.GetAsync<Scheme>($"{Action_GetScheme}{name}");

            Console.WriteLine($"Security Scheme {scheme.Name}:");
            Console.WriteLine($"G = {scheme.G}");
            Console.WriteLine($"T = {scheme.T}");
            Console.WriteLine($"P = {scheme.P}");
            Console.WriteLine($"Q = {scheme.Q}");

            return scheme;
        }
    }
}
