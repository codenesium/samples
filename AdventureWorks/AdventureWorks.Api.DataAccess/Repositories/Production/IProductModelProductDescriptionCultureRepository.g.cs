using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		Task<POCOProductModelProductDescriptionCulture> Create(ApiProductModelProductDescriptionCultureModel model);

		Task Update(int productModelID,
		            ApiProductModelProductDescriptionCultureModel model);

		Task Delete(int productModelID);

		Task<POCOProductModelProductDescriptionCulture> Get(int productModelID);

		Task<List<POCOProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d76872892428f00ec036fed5d1d3dd96</Hash>
</Codenesium>*/