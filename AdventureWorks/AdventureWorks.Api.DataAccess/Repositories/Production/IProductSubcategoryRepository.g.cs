using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductSubcategoryRepository
	{
		Task<POCOProductSubcategory> Create(ApiProductSubcategoryModel model);

		Task Update(int productSubcategoryID,
		            ApiProductSubcategoryModel model);

		Task Delete(int productSubcategoryID);

		Task<POCOProductSubcategory> Get(int productSubcategoryID);

		Task<List<POCOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductSubcategory> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>76a4d394c4448248ef7ff69c8222fbf9</Hash>
</Codenesium>*/