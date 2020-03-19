using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        private const string GRPC_ADDRESS = "https://localhost:5001";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Press enter to make gRPC Request.");
            Console.ReadLine();

            var channel = GrpcChannel.ForAddress(GRPC_ADDRESS);
            var client = new Persons.PersonsClient(channel);

            var personRequest = new PersonRequest() { UserId = 1 };
            var reply = await client.GetPersonAsync(personRequest);

            Console.WriteLine($"Firstname:{reply.FirstName} LastName:{reply.LastName} Verified:{reply.IsVerified}");

            Console.ReadLine();
        }
    }
}
