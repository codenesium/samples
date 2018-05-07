using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkStatus
	{
		Task<CreateResponse<int>> Create(
			LinkStatusModel model);

		Task<ActionResponse> Update(int id,
		                            LinkStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOLinkStatus Get(int id);

		List<POCOLinkStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>58fdbc5af856df9c53df87855cf62a70</Hash>
</Codenesium>*/