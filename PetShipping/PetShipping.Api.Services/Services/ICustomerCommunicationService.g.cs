using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface ICustomerCommunicationService
	{
		Task<CreateResponse<ApiCustomerCommunicationServerResponseModel>> Create(
			ApiCustomerCommunicationServerRequestModel model);

		Task<UpdateResponse<ApiCustomerCommunicationServerResponseModel>> Update(int id,
		                                                                          ApiCustomerCommunicationServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCustomerCommunicationServerResponseModel> Get(int id);

		Task<List<ApiCustomerCommunicationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCustomerCommunicationServerResponseModel>> ByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCustomerCommunicationServerResponseModel>> ByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1309d2acbbff8448edd03f4bd827d000</Hash>
</Codenesium>*/