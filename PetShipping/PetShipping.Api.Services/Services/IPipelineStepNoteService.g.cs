using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepNoteService
	{
		Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
			ApiPipelineStepNoteRequestModel model);

		Task<UpdateResponse<ApiPipelineStepNoteResponseModel>> Update(int id,
		                                                               ApiPipelineStepNoteRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepNoteResponseModel> Get(int id);

		Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>75a610cfe2b78912fee3da7e2518c2fb</Hash>
</Codenesium>*/