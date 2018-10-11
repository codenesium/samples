using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepService
	{
		Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
			ApiPipelineStepRequestModel model);

		Task<UpdateResponse<ApiPipelineStepResponseModel>> Update(int id,
		                                                           ApiPipelineStepRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepResponseModel> Get(int id);

		Task<List<ApiPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPipelineStepResponseModel>> ByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bd41fb4ec321052e9b275c4188f60c4e</Hash>
</Codenesium>*/