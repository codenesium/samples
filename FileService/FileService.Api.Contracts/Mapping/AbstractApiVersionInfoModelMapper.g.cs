using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
	public abstract class AbstractApiVersionInfoModelMapper
	{
		public virtual ApiVersionInfoResponseModel MapRequestToResponse(
			long version,
			ApiVersionInfoRequestModel request)
		{
			var response = new ApiVersionInfoResponseModel();
			response.SetProperties(version,
			                       request.AppliedOn,
			                       request.Description);
			return response;
		}

		public virtual ApiVersionInfoRequestModel MapResponseToRequest(
			ApiVersionInfoResponseModel response)
		{
			var request = new ApiVersionInfoRequestModel();
			request.SetProperties(
				response.AppliedOn,
				response.Description);
			return request;
		}

		public JsonPatchDocument<ApiVersionInfoRequestModel> CreatePatch(ApiVersionInfoRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVersionInfoRequestModel>();
			patch.Replace(x => x.AppliedOn, model.AppliedOn);
			patch.Replace(x => x.Description, model.Description);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5f39a1ee9ab9221e9b9a745eedd8d67c</Hash>
</Codenesium>*/