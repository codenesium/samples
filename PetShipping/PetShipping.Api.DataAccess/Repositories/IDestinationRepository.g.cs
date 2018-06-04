using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		Task<Destination> Create(Destination item);

		Task Update(Destination item);

		Task Delete(int id);

		Task<Destination> Get(int id);

		Task<List<Destination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f82f25ef74f338e784a24ae248cbca2c</Hash>
</Codenesium>*/