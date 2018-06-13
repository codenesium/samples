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

                Task<List<Airline>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>0ade54e37189ab7d640225cdf61e7c61</Hash>
</Codenesium>*/