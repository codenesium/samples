using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTimestampCheckServerModelMapper
	{
		public virtual ApiTimestampCheckServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTimestampCheckServerRequestModel request)
		{
			var response = new ApiTimestampCheckServerResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Timestamp);
			return response;
		}

		public virtual ApiTimestampCheckServerRequestModel MapServerResponseToRequest(
			ApiTimestampCheckServerResponseModel response)
		{
			var request = new ApiTimestampCheckServerRequestModel();
			request.SetProperties(
				response.Name,
				response.Timestamp);
			return request;
		}

		public virtual ApiTimestampCheckClientRequestModel MapServerResponseToClientRequest(
			ApiTimestampCheckServerResponseModel response)
		{
			var request = new ApiTimestampCheckClientRequestModel();
			request.SetProperties(
				response.Name,
				response.Timestamp);
			return request;
		}

		public JsonPatchDocument<ApiTimestampCheckServerRequestModel> CreatePatch(ApiTimestampCheckServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTimestampCheckServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Timestamp, model.Timestamp);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ac11b1bc853067d061d5c0d0e8c253ac</Hash>
</Codenesium>*/