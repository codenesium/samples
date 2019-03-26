using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductSubcategoryService
	{
		Task<CreateResponse<ApiProductSubcategoryServerResponseModel>> Create(
			ApiProductSubcategoryServerRequestModel model);

		Task<UpdateResponse<ApiProductSubcategoryServerResponseModel>> Update(int productSubcategoryID,
		                                                                       ApiProductSubcategoryServerRequestModel model);

		Task<ActionResponse> Delete(int productSubcategoryID);

		Task<ApiProductSubcategoryServerResponseModel> Get(int productSubcategoryID);

		Task<List<ApiProductSubcategoryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiProductSubcategoryServerResponseModel> ByName(string name);

		Task<ApiProductSubcategoryServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiProductServerResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1a782828ea1a4312578fdb87fcb04fab</Hash>
</Codenesium>*/