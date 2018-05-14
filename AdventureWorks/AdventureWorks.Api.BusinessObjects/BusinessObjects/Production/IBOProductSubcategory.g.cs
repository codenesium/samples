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
		Task<CreateResponse<POCOProductSubcategory>> Create(
			ApiProductSubcategoryModel model);

		Task<ActionResponse> Update(int productSubcategoryID,
		                            ApiProductSubcategoryModel model);

		Task<ActionResponse> Delete(int productSubcategoryID);

		POCOProductSubcategory Get(int productSubcategoryID);

		List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductSubcategory GetName(string name);
	}
}

/*<Codenesium>
    <Hash>dcc1acbebc52130f412e9d9eacf9a96d</Hash>
</Codenesium>*/