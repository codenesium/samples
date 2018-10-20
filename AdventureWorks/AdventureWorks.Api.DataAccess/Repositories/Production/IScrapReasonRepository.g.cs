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

		Task<List<WorkOrder>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fe89617f3dd69a0b403d49a2f881c297</Hash>
</Codenesium>*/