using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStateRepository
	{
		Task<POCOState> Create(ApiStateModel model);

		Task Update(int id,
		            ApiStateModel model);

		Task Delete(int id);

		Task<POCOState> Get(int id);

		Task<List<POCOState>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e9b72f899c9728df2634e20e1f111115</Hash>
</Codenesium>*/