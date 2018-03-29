using System;
using System.Linq.Expressions;
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

		void GetById(int productID, Response response);

		void GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c98d9d9f0f7137fa3efccef9df3a18e9</Hash>
</Codenesium>*/