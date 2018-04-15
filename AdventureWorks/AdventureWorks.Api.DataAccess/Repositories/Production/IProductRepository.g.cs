using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductRepository
	{
		int Create(ProductModel model);

		void Update(int productID,
		            ProductModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProduct GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1839b82749d7543b968f7bea9720a9f2</Hash>
</Codenesium>*/