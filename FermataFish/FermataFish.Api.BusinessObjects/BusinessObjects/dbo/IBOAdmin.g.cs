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
		Task<CreateResponse<POCOAdmin>> Create(
			AdminModel model);

		Task<ActionResponse> Update(int id,
		                            AdminModel model);

		Task<ActionResponse> Delete(int id);

		POCOAdmin Get(int id);

		List<POCOAdmin> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7e4b0866cfa00f45103cc65170fd630e</Hash>
</Codenesium>*/