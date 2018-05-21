using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		Task<POCOProductModel> Create(ApiProductModelModel model);

		Task Update(int productModelID,
		            ApiProductModelModel model);

		Task Delete(int productModelID);

		Task<POCOProductModel> Get(int productModelID);

		Task<List<POCOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductModel> GetName(string name);
		Task<List<POCOProductModel>> GetCatalogDescription(string catalogDescription);
		Task<List<POCOProductModel>> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>475531a70327065188a2fc1e451e96bf</Hash>
</Codenesium>*/