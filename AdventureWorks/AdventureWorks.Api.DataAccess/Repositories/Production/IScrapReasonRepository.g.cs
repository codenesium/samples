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

		Task<List<ScrapReason>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ScrapReason> ByName(string name);

		Task<List<WorkOrder>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c744532154bc0b28c994deea7d312c0c</Hash>
</Codenesium>*/