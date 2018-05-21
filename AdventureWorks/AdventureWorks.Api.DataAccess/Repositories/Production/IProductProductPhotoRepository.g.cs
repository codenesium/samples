using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		Task<POCOProductProductPhoto> Create(ApiProductProductPhotoModel model);

		Task Update(int productID,
		            ApiProductProductPhotoModel model);

		Task Delete(int productID);

		Task<POCOProductProductPhoto> Get(int productID);

		Task<List<POCOProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f39992f77aba2772e4b4dee601563fbe</Hash>
</Codenesium>*/