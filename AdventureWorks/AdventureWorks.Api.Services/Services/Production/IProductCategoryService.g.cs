using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IProductCategoryService
	{
		Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model);

		Task<UpdateResponse<ApiProductCategoryResponseModel>> Update(int productCategoryID,
		                                                              ApiProductCategoryRequestModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		Task<ApiProductCategoryResponseModel> Get(int productCategoryID);

		Task<List<ApiProductCategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductCategoryResponseModel> ByName(string name);

		Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>77445431b6375b7f488d211fa234e0fe</Hash>
</Codenesium>*/