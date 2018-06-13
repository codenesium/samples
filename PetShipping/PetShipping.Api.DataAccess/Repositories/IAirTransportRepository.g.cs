using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IAirTransportRepository
        {
                Task<AirTransport> Create(AirTransport item);

                Task Update(AirTransport item);

                Task Delete(int airlineId);

                Task<AirTransport> Get(int airlineId);

                Task<List<AirTransport>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4b317601c3a92afcb1e6f991b7cdaa85</Hash>
</Codenesium>*/