using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductCostHistoryRepository
	{
		int Create(ProductCostHistoryModel model);

		void Update(int productID,
		            ProductCostHistoryModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductCostHistory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCostHistory> GetWhereDirect(Expression<Func<EFProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5fc16473874f304883b958fdf9c1cb1c</Hash>
</Codenesium>*/