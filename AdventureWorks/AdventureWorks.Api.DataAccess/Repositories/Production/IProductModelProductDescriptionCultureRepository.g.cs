using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelProductDescriptionCultureRepository
	{
		Task<DTOProductModelProductDescriptionCulture> Create(DTOProductModelProductDescriptionCulture dto);

		Task Update(int productModelID,
		            DTOProductModelProductDescriptionCulture dto);

		Task Delete(int productModelID);

		Task<DTOProductModelProductDescriptionCulture> Get(int productModelID);

		Task<List<DTOProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a0d1fcdaad125820f02aa9277def3e27</Hash>
</Codenesium>*/