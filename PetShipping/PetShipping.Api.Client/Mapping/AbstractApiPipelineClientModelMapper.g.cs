using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
{
	public abstract class AbstractApiPipelineModelMapper
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
    <Hash>3d61cde16355cab34e6f692eb99c6cd7</Hash>
</Codenesium>*/