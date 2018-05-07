using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		short Create(ScrapReasonModel model);

		void Update(short scrapReasonID,
		            ScrapReasonModel model);

		void Delete(short scrapReasonID);

		POCOScrapReason Get(short scrapReasonID);

		List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fd98428dfc35c891a1238b0e1168de73</Hash>
</Codenesium>*/