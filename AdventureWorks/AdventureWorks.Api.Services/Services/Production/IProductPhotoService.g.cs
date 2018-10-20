using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductPhotoService
	{
		Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
			ApiProductPhotoRequestModel model);

		Task<UpdateResponse<ApiProductPhotoResponseModel>> Update(int productPhotoID,
		                                                           ApiProductPhotoRequestModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		Task<ApiProductPhotoResponseModel> Get(int productPhotoID);

		Task<List<ApiProductPhotoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoesByProductPhotoID(int productPhotoID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b21fbeb11862aa971e6b366c36e5b395</Hash>
</Codenesium>*/