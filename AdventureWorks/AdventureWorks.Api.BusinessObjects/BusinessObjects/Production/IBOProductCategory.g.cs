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

		POCOProductCategory Get(int productCategoryID);

		List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ebb70ebf644f0a40d9f63b48ce927541</Hash>
</Codenesium>*/