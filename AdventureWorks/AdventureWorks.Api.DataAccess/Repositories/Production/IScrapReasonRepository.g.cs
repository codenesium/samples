using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		POCOScrapReason Create(ApiScrapReasonModel model);

		void Update(short scrapReasonID,
		            ApiScrapReasonModel model);

		void Delete(short scrapReasonID);

		POCOScrapReason Get(short scrapReasonID);

		List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOScrapReason GetName(string name);
	}
}

/*<Codenesium>
    <Hash>9a6021186d2c4de7da6c6e5358e1ff72</Hash>
</Codenesium>*/