using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		short Create(
			string name,
			DateTime modifiedDate);

		void Update(short scrapReasonID,
		            string name,
		            DateTime modifiedDate);

		void Delete(short scrapReasonID);

		Response GetById(short scrapReasonID);

		POCOScrapReason GetByIdDirect(short scrapReasonID);

		Response GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dc8827d38896c9c8c0e9592dafc806d5</Hash>
</Codenesium>*/