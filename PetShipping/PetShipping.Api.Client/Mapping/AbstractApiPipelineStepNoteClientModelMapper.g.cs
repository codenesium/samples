using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineStepNoteModelMapper
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
    <Hash>6cfde0e379dc6735cfdf3841ad9e3e0b</Hash>
</Codenesium>*/