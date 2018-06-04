using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		Task<ScrapReason> Create(ScrapReason item);

		Task Update(ScrapReason item);

		Task Delete(short scrapReasonID);

		Task<ScrapReason> Get(short scrapReasonID);

		Task<List<ScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ScrapReason> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>5ac15b8c678293352004e5f4c16ce765</Hash>
</Codenesium>*/