using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		Task<POCOProductDescription> Create(ApiProductDescriptionModel model);

		Task Update(int productDescriptionID,
		            ApiProductDescriptionModel model);

		Task Delete(int productDescriptionID);

		Task<POCOProductDescription> Get(int productDescriptionID);

		Task<List<POCOProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d76d4821692bc185d9a2d64aae85a2c5</Hash>
</Codenesium>*/