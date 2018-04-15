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

		ApiResponse GetById(short scrapReasonID);

		POCOScrapReason GetByIdDirect(short scrapReasonID);

		ApiResponse GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c3edaa22a03b7132132f51477621771</Hash>
</Codenesium>*/