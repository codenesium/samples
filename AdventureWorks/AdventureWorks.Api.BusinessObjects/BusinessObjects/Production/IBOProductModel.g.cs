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

		POCOProductModel Get(int productModelID);

		List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductModel GetName(string name);

		List<POCOProductModel> GetCatalogDescription(string catalogDescription);
		List<POCOProductModel> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>46c91556fd7b4e86f6f131dec46de28f</Hash>
</Codenesium>*/