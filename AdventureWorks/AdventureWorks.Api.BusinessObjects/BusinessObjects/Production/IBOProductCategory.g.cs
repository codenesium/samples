using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductCategory
	{
		Task<CreateResponse<int>> Create(
			ProductCategoryModel model);

		Task<ActionResponse> Update(int productCategoryID,
		                            ProductCategoryModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		ApiResponse GetById(int productCategoryID);

		POCOProductCategory GetByIdDirect(int productCategoryID);

		ApiResponse GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ca20b27f292855edd35daa1de72bfcdd</Hash>
</Codenesium>*/