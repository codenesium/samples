using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>075f7b4dac5b5cd9515f450d76c4e919</Hash>
</Codenesium>*/