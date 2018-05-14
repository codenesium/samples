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
			LinkLogModel model);

		Task<ActionResponse> Update(int id,
		                            LinkLogModel model);

		Task<ActionResponse> Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7253b3d1d154e070a71af6fa36346327</Hash>
</Codenesium>*/