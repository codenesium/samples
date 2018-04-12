using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		int Create(
			DateTime startDate,
			Nullable<DateTime> endDate,
			decimal standardCost,
			DateTime modifiedDate);

		void Update(int productID,
		            DateTime startDate,
		            Nullable<DateTime> endDate,
		            decimal standardCost,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductCostHistory GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>96e2fd873760bd85780f6bcdc4b271eb</Hash>
</Codenesium>*/