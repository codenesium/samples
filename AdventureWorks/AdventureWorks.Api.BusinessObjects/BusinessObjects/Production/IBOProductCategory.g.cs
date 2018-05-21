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
		Task<CreateResponse<POCOProductCategory>> Create(
			ApiProductCategoryModel model);

		Task<ActionResponse> Update(int productCategoryID,
		                            ApiProductCategoryModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		Task<POCOProductCategory> Get(int productCategoryID);

		Task<List<POCOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductCategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>83e6daa047c1a3f7c890fc2d2ece7f80</Hash>
</Codenesium>*/