using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductInventoryRepository
	{
		int Create(ProductInventoryModel model);

		void Update(int productID,
		            ProductInventoryModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductInventory GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3bd6efabc0923207a450225d018358a1</Hash>
</Codenesium>*/