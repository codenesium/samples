using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOAdmin
	{
		Task<CreateResponse<int>> Create(
			AdminModel model);

		Task<ActionResponse> Update(int id,
		                            AdminModel model);

		Task<ActionResponse> Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d6a124c8b408259cf51e8d0d2f93d5ef</Hash>
</Codenesium>*/