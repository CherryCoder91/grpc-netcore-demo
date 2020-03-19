using Grpc.Core;
using Microsoft.Extensions.Logging;
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
            } else if (request.UserId == 2)
            {
                response.UserId = 2;
                response.FirstName = "Cherry";
                response.LastName = "Coder91";
                response.IsVerified = true;
            } else if (request.UserId == 3)
            {
                response.UserId = 3;
                response.FirstName = "Mr";
                response.LastName = "Developer";
                response.IsVerified = false;
            }


            return Task.FromResult(response);
        }
    }
}
