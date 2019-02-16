using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IProductModelService
	{
		Task<CreateResponse<ApiProductModelServerResponseModel>> Create(
			ApiProductModelServerRequestModel model);

		Task<UpdateResponse<ApiProductModelServerResponseModel>> Update(int productModelID,
		                                                                 ApiProductModelServerRequestModel model);

		Task<ActionResponse> Delete(int productModelID);

		Task<ApiProductModelServerResponseModel> Get(int productModelID);

		Task<List<ApiProductModelServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<ApiProductModelServerResponseModel> ByName(string name);

		Task<ApiProductModelServerResponseModel> ByRowguid(Guid rowguid);

		Task<List<ApiProductModelServerResponseModel>> ByCatalogDescription(string catalogDescription, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductModelServerResponseModel>> ByInstruction(string instruction, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProductServerResponseModel>> ProductsByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d4d1cfc3fd2534baad1b49cf7d0051c1</Hash>
</Codenesium>*/