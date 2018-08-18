using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IScrapReasonRepository
	{
		Task<ScrapReason> Create(ScrapReason item);

		Task Update(ScrapReason item);

		Task Delete(short scrapReasonID);

		Task<ScrapReason> Get(short scrapReasonID);

		Task<List<ScrapReason>> All(int limit = int.MaxValue, int offset = 0);

		Task<ScrapReason> ByName(string name);

		Task<List<WorkOrder>> WorkOrders(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d964395a04312cc9a59d7fcd867f2605</Hash>
</Codenesium>*/