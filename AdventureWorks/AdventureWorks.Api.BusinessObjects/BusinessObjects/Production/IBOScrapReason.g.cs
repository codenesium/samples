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

		Task<POCOScrapReason> Get(short scrapReasonID);

		Task<List<POCOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOScrapReason> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>964de333e7d93d1160a428a7729e90e8</Hash>
</Codenesium>*/