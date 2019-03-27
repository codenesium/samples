using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface ICustomerService
	{
		Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model);

		Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(int id,
		                                                             ApiCustomerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCustomerServerResponseModel> Get(int id);

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>637af84ca5b30b45bfc64512a2078d9d</Hash>
</Codenesium>*/