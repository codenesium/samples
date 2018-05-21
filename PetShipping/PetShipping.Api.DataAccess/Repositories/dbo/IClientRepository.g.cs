using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		Task<POCOClient> Create(ApiClientModel model);

		Task Update(int id,
		            ApiClientModel model);

		Task Delete(int id);

		Task<POCOClient> Get(int id);

		Task<List<POCOClient>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>51ab6a10d8f9706ac8d2088015e259ad</Hash>
</Codenesium>*/