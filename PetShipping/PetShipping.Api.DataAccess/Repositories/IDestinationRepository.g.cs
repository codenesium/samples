using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>6c747f6ae73b3e8bd87dba6d0adcff78</Hash>
</Codenesium>*/