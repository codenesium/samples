using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductSubcategoryService
	{
		Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
			ApiProductSubcategoryRequestModel model);

		Task<UpdateResponse<ApiProductSubcategoryResponseModel>> Update(int productSubcategoryID,
		                                                                 ApiProductSubcategoryRequestModel model);

		Task<ActionResponse> Delete(int productSubcategoryID);

		Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID);

		Task<List<ApiProductSubcategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiProductSubcategoryResponseModel> ByName(string name);

		Task<List<ApiProductResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>08b0b4da7371d330734532b76c21a3dc</Hash>
</Codenesium>*/