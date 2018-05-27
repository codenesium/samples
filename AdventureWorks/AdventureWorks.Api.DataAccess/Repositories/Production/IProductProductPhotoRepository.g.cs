using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		Task<DTOProductProductPhoto> Create(DTOProductProductPhoto dto);

		Task Update(int productID,
		            DTOProductProductPhoto dto);

		Task Delete(int productID);

		Task<DTOProductProductPhoto> Get(int productID);

		Task<List<DTOProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8f4f5e4a492a1817b5a022108c56510a</Hash>
</Codenesium>*/