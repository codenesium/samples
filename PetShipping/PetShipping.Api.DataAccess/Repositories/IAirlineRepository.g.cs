using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IAirlineRepository
        {
                Task<Airline> Create(Airline item);

                Task Update(Airline item);

                Task Delete(int id);

                Task<Airline> Get(int id);

                Task<List<Airline>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1418e753b4fc51b6d90d63070751e673</Hash>
</Codenesium>*/