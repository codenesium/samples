using System;
using System.Linq.Expressions;
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

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProductListPriceHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5ca420d4550e3464629917eb5aeef863</Hash>
</Codenesium>*/