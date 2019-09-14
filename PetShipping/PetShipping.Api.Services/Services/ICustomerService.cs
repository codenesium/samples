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

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCustomerCommunicationServerResponseModel>> CustomerCommunicationsByCustomerId(int customerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cf364343c39e103d2abd9de17eb0b406</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/