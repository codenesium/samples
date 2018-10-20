using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductCategoryService
	{
		Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
			ApiProductCategoryRequestModel model);

		Task<UpdateResponse<ApiProductCategoryResponseModel>> Update(int productCategoryID,
		                                                              ApiProductCategoryRequestModel model);

		Task<ActionResponse> Delete(int productCategoryID);

		Task<ApiProductCategoryResponseModel> Get(int productCategoryID);

		Task<List<ApiProductCategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductCategoryResponseModel> ByName(string name);

		Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>062c617dd0267fbf44f24de2492663db</Hash>
</Codenesium>*/