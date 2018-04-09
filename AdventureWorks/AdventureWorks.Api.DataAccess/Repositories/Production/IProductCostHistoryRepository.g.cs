using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		int Create(DateTime startDate,
		           Nullable<DateTime> endDate,
		           decimal standardCost,
		           DateTime modifiedDate);

		void Update(int productID, DateTime startDate,
		            Nullable<DateTime> endDate,
		            decimal standardCost,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductCostHistory GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e12fae21516b0019f9cda09be8688930</Hash>
</Codenesium>*/