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

		POCOProductCategory Get(int productCategoryID);

		List<POCOProductCategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductCategory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>1cd03e4c9b634c4c3bd2daa49782a07e</Hash>
</Codenesium>*/