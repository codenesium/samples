using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductListPriceHistoryRepository
	{
		int Create(DateTime startDate,
		           Nullable<DateTime> endDate,
		           decimal listPrice,
		           DateTime modifiedDate);

		void Update(int productID, DateTime startDate,
		            Nullable<DateTime> endDate,
		            decimal listPrice,
		            DateTime modifiedDate);

		void Delete(int productID);

		Response GetById(int productID);

		POCOProductListPriceHistory GetByIdDirect(int productID);

		Response GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductListPriceHistory> GetWhereDirect(Expression<Func<EFProductListPriceHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7e8e04fba233a6f5b67eaa2cea259a29</Hash>
</Codenesium>*/