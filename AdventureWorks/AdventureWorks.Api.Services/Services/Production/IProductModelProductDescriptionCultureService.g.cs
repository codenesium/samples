using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductModelProductDescriptionCultureService
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
    <Hash>8d7acbd9422f8a450dc49f779ddf3f3a</Hash>
</Codenesium>*/