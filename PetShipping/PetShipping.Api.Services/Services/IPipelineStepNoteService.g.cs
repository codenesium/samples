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
    <Hash>88f738306f02881a3da657f40ce2c373</Hash>
</Codenesium>*/