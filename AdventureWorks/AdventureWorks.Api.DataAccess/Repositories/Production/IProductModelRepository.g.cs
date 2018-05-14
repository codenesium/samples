using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		POCOProductModel Create(ApiProductModelModel model);

		void Update(int productModelID,
		            ApiProductModelModel model);

		void Delete(int productModelID);

		POCOProductModel Get(int productModelID);

		List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOProductModel GetName(string name);

		List<POCOProductModel> GetCatalogDescription(string catalogDescription);
		List<POCOProductModel> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>2dbfd4f256782e076dc99dbb24fe3854</Hash>
</Codenesium>*/