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

		Task<POCOLinkLog> Get(int id);

		Task<List<POCOLinkLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f166e084d38c867a58b284647eff38ce</Hash>
</Codenesium>*/