using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IAirlineRepository
	{
		Task<Airline> Create(Airline item);

		Task Update(Airline item);

		Task Delete(int id);

		Task<Airline> Get(int id);

		Task<List<Airline>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>ba6e58bcd06bd97e560b2643f6b7c4c2</Hash>
</Codenesium>*/