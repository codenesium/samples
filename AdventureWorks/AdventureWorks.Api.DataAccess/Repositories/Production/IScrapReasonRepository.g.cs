using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		Task<DTOScrapReason> Create(DTOScrapReason dto);

		Task Update(short scrapReasonID,
		            DTOScrapReason dto);

		Task Delete(short scrapReasonID);

		Task<DTOScrapReason> Get(short scrapReasonID);

		Task<List<DTOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOScrapReason> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>9ee8fccec3a8a2189c07c6e666d58fcd</Hash>
</Codenesium>*/