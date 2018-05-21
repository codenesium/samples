using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		Task<POCOScrapReason> Create(ApiScrapReasonModel model);

		Task Update(short scrapReasonID,
		            ApiScrapReasonModel model);

		Task Delete(short scrapReasonID);

		Task<POCOScrapReason> Get(short scrapReasonID);

		Task<List<POCOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOScrapReason> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>95f26e7c820b6da51ad8f052c657f98b</Hash>
</Codenesium>*/