using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelRepository
	{
		Task<DTOProductModel> Create(DTOProductModel dto);

		Task Update(int productModelID,
		            DTOProductModel dto);

		Task Delete(int productModelID);

		Task<DTOProductModel> Get(int productModelID);

		Task<List<DTOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOProductModel> GetName(string name);
		Task<List<DTOProductModel>> GetCatalogDescription(string catalogDescription);
		Task<List<DTOProductModel>> GetInstructions(string instructions);
	}
}

/*<Codenesium>
    <Hash>5a94708f1413671f26e5b0109d092548</Hash>
</Codenesium>*/