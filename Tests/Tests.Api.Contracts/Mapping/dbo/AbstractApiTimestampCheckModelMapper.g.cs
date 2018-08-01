using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiTimestampCheckModelMapper
	{
		public virtual ApiTimestampCheckResponseModel MapRequestToResponse(
			int id,
			ApiTimestampCheckRequestModel request)
		{
			var response = new ApiTimestampCheckResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Timestamp);
			return response;
		}

		public virtual ApiTimestampCheckRequestModel MapResponseToRequest(
			ApiTimestampCheckResponseModel response)
		{
			var request = new ApiTimestampCheckRequestModel();
			request.SetProperties(
				response.Name,
				response.Timestamp);
			return request;
		}

		public JsonPatchDocument<ApiTimestampCheckRequestModel> CreatePatch(ApiTimestampCheckRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTimestampCheckRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Timestamp, model.Timestamp);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a9a3c423cdb000d98acfacb7f24eaafc</Hash>
</Codenesium>*/