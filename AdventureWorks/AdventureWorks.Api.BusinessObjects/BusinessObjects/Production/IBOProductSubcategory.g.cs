using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductSubcategory
	{
		Task<CreateResponse<int>> Create(
			ProductSubcategoryModel model);

		Task<ActionResponse> Update(int productSubcategoryID,
		                            ProductSubcategoryModel model);

		Task<ActionResponse> Delete(int productSubcategoryID);

		ApiResponse GetById(int productSubcategoryID);

		POCOProductSubcategory GetByIdDirect(int productSubcategoryID);

		ApiResponse GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b2a2fbd2c4e38f68d17b63d400593789</Hash>
</Codenesium>*/