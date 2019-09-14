using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public class ApiPipelineModelMapper : IApiPipelineModelMapper
	{
		public virtual ApiPipelineClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPipelineClientRequestModel request)
		{
			var response = new ApiPipelineClientResponseModel();
			response.SetProperties(id,
			                       request.PipelineStatusId,
			                       request.SaleId);
			return response;
		}

		public virtual ApiPipelineClientRequestModel MapClientResponseToRequest(
			ApiPipelineClientResponseModel response)
		{
			var request = new ApiPipelineClientRequestModel();
			request.SetProperties(
				response.PipelineStatusId,
				response.SaleId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d962ff4f7f891d884851ccc2b4e84c9e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/