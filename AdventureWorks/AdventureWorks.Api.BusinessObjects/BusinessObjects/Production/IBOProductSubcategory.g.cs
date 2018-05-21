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

		Task<POCOProductSubcategory> Get(int productSubcategoryID);

		Task<List<POCOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductSubcategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>41d155859cc2c271fe844683afd43dc7</Hash>
</Codenesium>*/