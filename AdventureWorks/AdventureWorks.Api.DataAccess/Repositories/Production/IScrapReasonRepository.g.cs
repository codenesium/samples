using System;
using System.Linq.Expressions;
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

		void GetById(short scrapReasonID, Response response);

		void GetWhere(Expression<Func<EFScrapReason, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>58ea7ac514dd332b1f7fcdd472cd3fee</Hash>
</Codenesium>*/