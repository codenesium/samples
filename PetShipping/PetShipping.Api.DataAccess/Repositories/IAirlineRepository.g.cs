using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>bca002f1b52ecee4ce159fca613dc517</Hash>
</Codenesium>*/