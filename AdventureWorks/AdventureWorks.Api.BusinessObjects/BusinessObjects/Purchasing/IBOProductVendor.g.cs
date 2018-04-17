using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductVendor
	{
		Task<CreateResponse<int>> Create(
			ProductVendorModel model);

		Task<ActionResponse> Update(int productID,
		                            ProductVendorModel model);

		Task<ActionResponse> Delete(int productID);

		ApiResponse GetById(int productID);

		POCOProductVendor GetByIdDirect(int productID);

		ApiResponse GetWhere(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductVendor> GetWhereDirect(Expression<Func<EFProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7ca4ed6270f65159f3159cbe6595ff9c</Hash>
</Codenesium>*/