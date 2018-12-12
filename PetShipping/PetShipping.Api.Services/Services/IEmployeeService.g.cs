using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeServerResponseModel>> Create(
			ApiEmployeeServerRequestModel model);

		Task<UpdateResponse<ApiEmployeeServerResponseModel>> Update(int id,
		                                                             ApiEmployeeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEmployeeServerResponseModel> Get(int id);

		Task<List<ApiEmployeeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCustomerCommunicationServerResponseModel>> CustomerCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c28987e55b02c4536543ec6ca87b4760</Hash>
</Codenesium>*/