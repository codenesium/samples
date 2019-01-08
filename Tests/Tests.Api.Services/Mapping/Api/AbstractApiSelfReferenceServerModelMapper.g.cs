using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiSelfReferenceServerModelMapper
	{
		public virtual ApiSelfReferenceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSelfReferenceServerRequestModel request)
		{
			var response = new ApiSelfReferenceServerResponseModel();
			response.SetProperties(id,
			                       request.SelfReferenceId,
			                       request.SelfReferenceId2);
			return response;
		}

		public virtual ApiSelfReferenceServerRequestModel MapServerResponseToRequest(
			ApiSelfReferenceServerResponseModel response)
		{
			var request = new ApiSelfReferenceServerRequestModel();
			request.SetProperties(
				response.SelfReferenceId,
				response.SelfReferenceId2);
			return request;
		}

		public virtual ApiSelfReferenceClientRequestModel MapServerResponseToClientRequest(
			ApiSelfReferenceServerResponseModel response)
		{
			var request = new ApiSelfReferenceClientRequestModel();
			request.SetProperties(
				response.SelfReferenceId,
				response.SelfReferenceId2);
			return request;
		}

		public JsonPatchDocument<ApiSelfReferenceServerRequestModel> CreatePatch(ApiSelfReferenceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSelfReferenceServerRequestModel>();
			patch.Replace(x => x.SelfReferenceId, model.SelfReferenceId);
			patch.Replace(x => x.SelfReferenceId2, model.SelfReferenceId2);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d372e644eb4fa53c5854492845d97f06</Hash>
</Codenesium>*/