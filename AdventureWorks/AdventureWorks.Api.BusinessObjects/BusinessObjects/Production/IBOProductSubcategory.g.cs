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

		POCOProductSubcategory Get(int productSubcategoryID);

		List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4d2ce58c861ff590bf700bc6d1d7bf75</Hash>
</Codenesium>*/