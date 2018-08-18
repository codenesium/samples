using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductModelProductDescriptionCultureService
	{
		Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
			ApiProductModelProductDescriptionCultureRequestModel model);

		Task<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Update(int productModelID,
		                                                                                    ApiProductModelProductDescriptionCultureRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID);

		Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c28b8bf859afd033af08e2a26f5ae72c</Hash>
</Codenesium>*/