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

                Task<List<Destination>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<PipelineStepDestination>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>707ef73c3716eaaae7617b4a9818afd4</Hash>
</Codenesium>*/