using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkLog
	{
		Task<CreateResponse<POCOLinkLog>> Create(
			ApiLinkLogModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkLogModel model);

		Task<ActionResponse> Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c8d169ebb8f8c7985ca83e14b949694</Hash>
</Codenesium>*/