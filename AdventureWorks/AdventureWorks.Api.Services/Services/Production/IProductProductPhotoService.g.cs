using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductProductPhotoService
	{
		Task<CreateResponse<ApiProductProductPhotoServerResponseModel>> Create(
			ApiProductProductPhotoServerRequestModel model);

		Task<UpdateResponse<ApiProductProductPhotoServerResponseModel>> Update(int productID,
		                                                                        ApiProductProductPhotoServerRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductProductPhotoServerResponseModel> Get(int productID);

		Task<List<ApiProductProductPhotoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6a3402fa959004d6b43b861528f4c41a</Hash>
</Codenesium>*/