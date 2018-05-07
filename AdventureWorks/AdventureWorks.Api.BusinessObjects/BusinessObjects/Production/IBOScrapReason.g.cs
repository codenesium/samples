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
		Task<CreateResponse<short>> Create(
			ScrapReasonModel model);

		Task<ActionResponse> Update(short scrapReasonID,
		                            ScrapReasonModel model);

		Task<ActionResponse> Delete(short scrapReasonID);

		POCOScrapReason Get(short scrapReasonID);

		List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>effbc96be9cf3ccaeba685b744194572</Hash>
</Codenesium>*/