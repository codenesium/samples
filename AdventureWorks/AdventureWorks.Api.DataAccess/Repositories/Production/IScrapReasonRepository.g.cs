using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IScrapReasonRepository
	{
		short Create(string name,
		             DateTime modifiedDate);

		void Update(short scrapReasonID, string name,
		            DateTime modifiedDate);

		void Delete(short scrapReasonID);

		Response GetById(short scrapReasonID);

		POCOScrapReason GetByIdDirect(short scrapReasonID);

		Response GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e1b09605a83bdf419add0623ee8bc08b</Hash>
</Codenesium>*/