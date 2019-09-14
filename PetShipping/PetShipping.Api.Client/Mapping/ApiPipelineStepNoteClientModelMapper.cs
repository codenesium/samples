using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineStepNoteModelMapper : IApiPipelineStepNoteModelMapper
	{
		public virtual ApiPipelineStepNoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineStepNoteClientRequestModel request)
		{
			var response = new ApiPipelineStepNoteClientResponseModel();
			response.SetProperties(id,
			                       request.EmployeeId,
			                       request.Note,
			                       request.PipelineStepId);
			return response;
		}

		public virtual ApiPipelineStepNoteClientRequestModel MapClientResponseToRequest(
			ApiPipelineStepNoteClientResponseModel response)
		{
			var request = new ApiPipelineStepNoteClientRequestModel();
			request.SetProperties(
				response.EmployeeId,
				response.Note,
				response.PipelineStepId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>3f5224fefb6708931170a670affd92dc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/