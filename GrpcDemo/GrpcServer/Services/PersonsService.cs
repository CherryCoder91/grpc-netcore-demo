using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class PersonsService : Persons.PersonsBase
    {
        private readonly ILogger<PersonsService> _logger;

        public PersonsService(ILogger<PersonsService> logger)
        {
            this._logger = logger;
        }

        public override Task<PersonResponse> GetPerson(PersonRequest request, ServerCallContext context)
        {
            PersonResponse response = new PersonResponse();

            if (request.UserId == 1)
            {
                response.UserId = 1;
                response.FirstName = "James";
                response.LastName = "Pickup";
                response.IsVerified = true;
            }
            else if (request.UserId == 2)
            {
                response.UserId = 2;
                response.FirstName = "Cherry";
                response.LastName = "Coder91";
                response.IsVerified = true;
            }
            else if (request.UserId == 3)
            {
                response.UserId = 3;
                response.FirstName = "Mr";
                response.LastName = "Developer";
                response.IsVerified = false;
            }


            return Task.FromResult(response);
        }

        public override async Task GetPersons(PersonsRequest request, IServerStreamWriter<PersonResponse> responseStream, ServerCallContext context)
        {
            List<PersonResponse> persons = new List<PersonResponse>
            {
                new PersonResponse
                {
                    UserId = 1,
                    FirstName = "James",
                    LastName = "Pickup",
                    IsVerified = true
                },
                new PersonResponse
                {
                    UserId = 2,
                    FirstName = "Cherry",
                    LastName = "Coder91",
                    IsVerified = true
                },
                new PersonResponse
                {
                    UserId = 3,
                    FirstName = "Mr",
                    LastName = "Developer",
                    IsVerified = false
                }
            };

            foreach (var person in persons)
            {
                await responseStream.WriteAsync(person);
                await Task.Delay(2000); // Artiftical delay to demonstrate streaming more clearly in the client. Not a production concept!
            }

        }
    }
}
