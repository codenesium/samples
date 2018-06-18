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

                Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0);

                Task<Handler> GetHandler(int handlerId);
        }
}

/*<Codenesium>
    <Hash>880c6e08acd81f203ceaf08bea426b2d</Hash>
</Codenesium>*/