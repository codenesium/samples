using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public class ApiTimestampCheckServerModelMapper : IApiTimestampCheckServerModelMapper
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
    <Hash>158604744127b7f3154b9e947796d455</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/