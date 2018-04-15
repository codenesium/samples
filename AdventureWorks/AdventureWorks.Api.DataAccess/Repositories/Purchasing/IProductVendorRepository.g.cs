using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductVendorRepository
	{
		int Create(ProductVendorModel model);

		void Update(int productID,
		            ProductVendorModel model);

		void Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductVendor GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>793b8318e316f4d7f2a9106593354d8d</Hash>
</Codenesium>*/