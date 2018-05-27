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
		Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model);

		Task<ActionResponse> Update(int productID,
		                            ApiProductProductPhotoRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductProductPhotoResponseModel> Get(int productID);

		Task<List<ApiProductProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>69f63441c7208f1169f1564cff613b99</Hash>
</Codenesium>*/