using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductProductPhotoService
	{
		Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
			ApiProductProductPhotoRequestModel model);

		Task<UpdateResponse<ApiProductProductPhotoResponseModel>> Update(int productID,
		                                                                  ApiProductProductPhotoRequestModel model);

		Task<ActionResponse> Delete(int productID);

		Task<ApiProductProductPhotoResponseModel> Get(int productID);

		Task<List<ApiProductProductPhotoResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>80b3b08c916aa3dd0a3ff9b803bbefd2</Hash>
</Codenesium>*/