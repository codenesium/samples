using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ISpaceRepository
	{
		Task<POCOSpace> Create(ApiSpaceModel model);

		Task Update(int id,
		            ApiSpaceModel model);

		Task Delete(int id);

		Task<POCOSpace> Get(int id);

		Task<List<POCOSpace>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>22b18ff0e814e95326b14c6047fa55ea</Hash>
</Codenesium>*/