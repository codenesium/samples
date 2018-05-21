using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IAdminRepository
	{
		Task<POCOAdmin> Create(ApiAdminModel model);

		Task Update(int id,
		            ApiAdminModel model);

		Task Delete(int id);

		Task<POCOAdmin> Get(int id);

		Task<List<POCOAdmin>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>94062059678eb44d8f21091589ee53fb</Hash>
</Codenesium>*/