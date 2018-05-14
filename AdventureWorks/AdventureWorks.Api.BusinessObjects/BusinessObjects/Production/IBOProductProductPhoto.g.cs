using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductProductPhoto
	{
		Task<CreateResponse<POCOProductProductPhoto>> Create(
			ApiProductProductPhotoModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductProductPhotoModel model);

		Task<ActionResponse> Delete(int productID);

		POCOProductProductPhoto Get(int productID);

		List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>09e8f4f1a8242650098a1642496efcd1</Hash>
</Codenesium>*/