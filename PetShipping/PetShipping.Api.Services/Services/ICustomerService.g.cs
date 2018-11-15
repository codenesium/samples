using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface ICustomerService
	{
		Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model);

		Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(int id,
		                                                             ApiCustomerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCustomerServerResponseModel> Get(int id);

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCustomerCommunicationServerResponseModel>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d47b5a8834cfcea978872bab9e433161</Hash>
</Codenesium>*/