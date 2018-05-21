using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModel
	{
		Task<CreateResponse<POCOProductModel>> Create(
			ApiProductModelModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<POCOProductModel> Get(int productModelID);

		Task<List<POCOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOProductModel> GetName(string name);
		Task<List<POCOProductModel>> GetCatalogDescription(string catalogDescription);
		Task<List<POCOProductModel>> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>c6995a00e5ba34661616c9c31846bd0c</Hash>
</Codenesium>*/