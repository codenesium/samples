using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOSpace
	{
		Task<CreateResponse<POCOSpace>> Create(
			ApiSpaceModel model);

		Task<ActionResponse> Update(int id,
		                            ApiSpaceModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOSpace> Get(int id);

		Task<List<POCOSpace>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dc35f98afe30dc2d17b8868b1abe6e89</Hash>
</Codenesium>*/