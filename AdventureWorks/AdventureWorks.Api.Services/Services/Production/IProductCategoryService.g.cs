using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductCategoryService
	{
		Task<CreateResponse<ApiProductCategoryServerResponseModel>> Create(
			ApiProductCategoryServerRequestModel model);

		Task<UpdateResponse<ApiProductCategoryServerResponseModel>> Update(int productCategoryID,
		                                                                    ApiProductCategoryServerRequestModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		Task<ApiProductCategoryServerResponseModel> Get(int productCategoryID);

		Task<List<ApiProductCategoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductCategoryServerResponseModel> ByName(string name);

		Task<ApiProductCategoryServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiProductSubcategoryServerResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0f9d1b3307cd82e9949e765bc907e5aa</Hash>
</Codenesium>*/