using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		Task<POCOProductPhoto> Create(ApiProductPhotoModel model);

		Task Update(int productPhotoID,
		            ApiProductPhotoModel model);

		Task Delete(int productPhotoID);

		Task<POCOProductPhoto> Get(int productPhotoID);

		Task<List<POCOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a962d2ee4cd0f78e25a5de1bd85bf039</Hash>
</Codenesium>*/