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

                Task<List<Airline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9dfa7486bab6aec79fe6471d845c99e7</Hash>
</Codenesium>*/