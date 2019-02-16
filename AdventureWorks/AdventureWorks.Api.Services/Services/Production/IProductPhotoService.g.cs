using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductPhotoService
	{
		Task<CreateResponse<ApiProductPhotoServerResponseModel>> Create(
			ApiProductPhotoServerRequestModel model);

		Task<UpdateResponse<ApiProductPhotoServerResponseModel>> Update(int productPhotoID,
		                                                                 ApiProductPhotoServerRequestModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		Task<ApiProductPhotoServerResponseModel> Get(int productPhotoID);

		Task<List<ApiProductPhotoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4a378db659c06a6af0c9c64f919964d0</Hash>
</Codenesium>*/