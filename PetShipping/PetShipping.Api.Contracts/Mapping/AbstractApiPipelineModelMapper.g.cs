using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiPipelineModelMapper
	{
		public virtual ApiPipelineResponseModel MapRequestToResponse(
			int id,
			ApiPipelineRequestModel request)
		{
			var response = new ApiPipelineResponseModel();
			response.SetProperties(id,
			                       request.PipelineStatusId,
			                       request.SaleId);
			return response;
		}

		public virtual ApiPipelineRequestModel MapResponseToRequest(
			ApiPipelineResponseModel response)
		{
			var request = new ApiPipelineRequestModel();
			request.SetProperties(
				response.PipelineStatusId,
				response.SaleId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineRequestModel> CreatePatch(ApiPipelineRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineRequestModel>();
			patch.Replace(x => x.PipelineStatusId, model.PipelineStatusId);
			patch.Replace(x => x.SaleId, model.SaleId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e8063fa360ea68d72f413b2c156fb33a</Hash>
</Codenesium>*/