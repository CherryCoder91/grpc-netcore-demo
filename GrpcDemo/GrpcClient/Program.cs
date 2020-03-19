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
            Console.WriteLine("Press enter to make gRPC Request");
            Console.ReadLine();

            var channel = GrpcChannel.ForAddress(GRPC_ADDRESS);
            var client = new Greeter.GreeterClient(channel);

            HelloRequest request = new HelloRequest();
            var response = await client.SayHelloAsync(request);

            Console.WriteLine($"Message: {response.Message}");

            Console.ReadLine();
        }
    }
}
