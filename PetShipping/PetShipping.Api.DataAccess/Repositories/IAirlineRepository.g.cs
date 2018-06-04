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
    <Hash>e2194c336fb74c6172d7937d1bd93436</Hash>
</Codenesium>*/