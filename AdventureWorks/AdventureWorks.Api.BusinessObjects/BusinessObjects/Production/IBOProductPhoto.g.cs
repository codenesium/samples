using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductPhoto
	{
		Task<CreateResponse<POCOProductPhoto>> Create(
			ApiProductPhotoModel model);

		Task<ActionResponse> Update(int productPhotoID,
		                            ApiProductPhotoModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		POCOProductPhoto Get(int productPhotoID);

		List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>39ae1e70c2c2c647d787990050aa1850</Hash>
</Codenesium>*/