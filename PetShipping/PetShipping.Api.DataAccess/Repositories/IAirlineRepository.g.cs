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
    <Hash>7232cf9419246ced16b5d4a09370ffc6</Hash>
</Codenesium>*/