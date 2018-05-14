using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOScrapReason
	{
		Task<CreateResponse<POCOScrapReason>> Create(
			ApiScrapReasonModel model);

		Task<ActionResponse> Update(short scrapReasonID,
		                            ApiScrapReasonModel model);

		Task<ActionResponse> Delete(short scrapReasonID);

		POCOScrapReason Get(short scrapReasonID);

		List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOScrapReason GetName(string name);
	}
}

/*<Codenesium>
    <Hash>cf0ec744529d6c99ea1efe9734f16b2d</Hash>
</Codenesium>*/