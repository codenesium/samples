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

		Task<List<ApiProductPhotoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b5e15d64525a235ecd02c3052eb2a953</Hash>
</Codenesium>*/