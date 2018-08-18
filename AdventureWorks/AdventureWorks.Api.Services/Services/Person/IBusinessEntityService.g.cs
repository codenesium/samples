using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBusinessEntityService
	{
		Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model);

		Task<UpdateResponse<ApiBusinessEntityResponseModel>> Update(int businessEntityID,
		                                                             ApiBusinessEntityRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiBusinessEntityResponseModel> Get(int businessEntityID);

		Task<List<ApiBusinessEntityResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityAddressResponseModel>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonResponseModel>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>03d81e7e9b7d334ae8737fdc6e0a7009</Hash>
</Codenesium>*/