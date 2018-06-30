using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IDestinationRepository
        {
                Task<Destination> Create(Destination item);

                Task Update(Destination item);

                Task Delete(int id);

                Task<Destination> Get(int id);

                Task<List<Destination>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PipelineStepDestination>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);

                Task<Country> GetCountry(int countryId);
        }
}

/*<Codenesium>
    <Hash>0a4884b9fcf853e3e89739d14e65c069</Hash>
</Codenesium>*/