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
		Task<CreateResponse<int>> Create(
			LinkLogModel model);

		Task<ActionResponse> Update(int id,
		                            LinkLogModel model);

		Task<ActionResponse> Delete(int id);

		POCOLinkLog Get(int id);

		List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>90931e5cdcf1ad4d6c2310bd14a1f2e6</Hash>
</Codenesium>*/