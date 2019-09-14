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

		Task<List<ApiPipelineStepNoteServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>ae6a56139fbd5b4aac7a7c28039b1ee9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/