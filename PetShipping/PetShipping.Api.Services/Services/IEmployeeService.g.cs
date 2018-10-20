using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IEmployeeService
	{
		Task<CreateResponse<ApiEmployeeResponseModel>> Create(
			ApiEmployeeRequestModel model);

		Task<UpdateResponse<ApiEmployeeResponseModel>> Update(int id,
		                                                       ApiEmployeeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEmployeeResponseModel> Get(int id);

		Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiClientCommunicationResponseModel>> ClientCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepResponseModel>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ad55d77fcb8d42e6094fc403d72f09dc</Hash>
</Codenesium>*/