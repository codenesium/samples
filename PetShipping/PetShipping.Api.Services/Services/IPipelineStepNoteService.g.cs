using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepNoteService
	{
		Task<CreateResponse<ApiPipelineStepNoteServerResponseModel>> Create(
			ApiPipelineStepNoteServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepNoteServerResponseModel>> Update(int id,
		                                                                     ApiPipelineStepNoteServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepNoteServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepNoteServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c68631ef9abafef20ba5ad7ee2dd23f6</Hash>
</Codenesium>*/