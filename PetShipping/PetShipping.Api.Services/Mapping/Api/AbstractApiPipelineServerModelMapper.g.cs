using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiPipelineServerModelMapper
	{
		public virtual ApiPipelineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPipelineServerRequestModel request)
		{
			var response = new ApiPipelineServerResponseModel();
			response.SetProperties(id,
			                       request.PipelineStatusId,
			                       request.SaleId);
			return response;
		}

		public virtual ApiPipelineServerRequestModel MapServerResponseToRequest(
			ApiPipelineServerResponseModel response)
		{
			var request = new ApiPipelineServerRequestModel();
			request.SetProperties(
				response.PipelineStatusId,
				response.SaleId);
			return request;
		}

		public virtual ApiPipelineClientRequestModel MapServerResponseToClientRequest(
			ApiPipelineServerResponseModel response)
		{
			var request = new ApiPipelineClientRequestModel();
			request.SetProperties(
				response.PipelineStatusId,
				response.SaleId);
			return request;
		}

		public JsonPatchDocument<ApiPipelineServerRequestModel> CreatePatch(ApiPipelineServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPipelineServerRequestModel>();
			patch.Replace(x => x.PipelineStatusId, model.PipelineStatusId);
			patch.Replace(x => x.SaleId, model.SaleId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be4d3348b55491c354898e0e28766ea0</Hash>
</Codenesium>*/