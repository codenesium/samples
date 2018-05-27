using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		Task<DTOProductPhoto> Create(DTOProductPhoto dto);

		Task Update(int productPhotoID,
		            DTOProductPhoto dto);

		Task Delete(int productPhotoID);

		Task<DTOProductPhoto> Get(int productPhotoID);

		Task<List<DTOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5b89b4f7042e0b00a3aeda9dbf8a9838</Hash>
</Codenesium>*/