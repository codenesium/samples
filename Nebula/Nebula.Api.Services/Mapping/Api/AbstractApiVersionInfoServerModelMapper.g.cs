using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiVersionInfoServerModelMapper
	{
		public virtual ApiVersionInfoServerResponseModel MapServerRequestToResponse(
			long version,
			ApiVersionInfoServerRequestModel request)
		{
			var response = new ApiVersionInfoServerResponseModel();
			response.SetProperties(version,
			                       request.AppliedOn,
			                       request.Description);
			return response;
		}

		public virtual ApiVersionInfoServerRequestModel MapServerResponseToRequest(
			ApiVersionInfoServerResponseModel response)
		{
			var request = new ApiVersionInfoServerRequestModel();
			request.SetProperties(
				response.AppliedOn,
				response.Description);
			return request;
		}

		public virtual ApiVersionInfoClientRequestModel MapServerResponseToClientRequest(
			ApiVersionInfoServerResponseModel response)
		{
			var request = new ApiVersionInfoClientRequestModel();
			request.SetProperties(
				response.AppliedOn,
				response.Description);
			return request;
		}

		public JsonPatchDocument<ApiVersionInfoServerRequestModel> CreatePatch(ApiVersionInfoServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVersionInfoServerRequestModel>();
			patch.Replace(x => x.AppliedOn, model.AppliedOn);
			patch.Replace(x => x.Description, model.Description);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d8b7fd076073af15db87840274c43d80</Hash>
</Codenesium>*/