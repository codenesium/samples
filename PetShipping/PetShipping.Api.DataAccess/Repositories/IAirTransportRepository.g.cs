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

                Task<List<AirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ce3bf093573ba8c41c5b2fbc23deae7e</Hash>
</Codenesium>*/