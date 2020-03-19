using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        private const string GRPC_ADDRESS = "https://localhost:5001";

        static async Task Main(string[] args)
        {
            await DemonstrateStreaming();
            //await DemonstrateSingleRequest();
        }

        /// <summary>
        ///     Demonstrates a gRPC call that streams in multiple responses.
        /// </summary>
        /// <returns>Void Task</returns>
        private async static Task DemonstrateStreaming()
        {

            Console.WriteLine("Press enter to make gRPC Request.");
            Console.ReadLine();

            var channel = GrpcChannel.ForAddress(GRPC_ADDRESS);
            var client = new Persons.PersonsClient(channel);

            using (var clientRequest = client.GetPersons(new PersonsRequest()))
            {
                CancellationTokenSource source = new CancellationTokenSource();
                while (await clientRequest.ResponseStream.MoveNext(source.Token))
                {
                    var person = clientRequest.ResponseStream.Current;
                    Console.WriteLine($"Firstname: {person.FirstName} Lastname: {person.LastName} Verified: {person.IsVerified}");
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        ///     Demonstrates a gRPC call that makes a request for a singular item
        /// </summary>
        /// <returns>Void Task</returns>
        private async static Task DemonstrateSingleRequest()
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
