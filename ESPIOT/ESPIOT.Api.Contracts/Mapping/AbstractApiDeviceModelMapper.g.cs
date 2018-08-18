using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Contracts
{
	public abstract class AbstractApiDeviceModelMapper
	{
		public virtual ApiDeviceResponseModel MapRequestToResponse(
			int id,
			ApiDeviceRequestModel request)
		{
			var response = new ApiDeviceResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PublicId);
			return response;
		}

		public virtual ApiDeviceRequestModel MapResponseToRequest(
			ApiDeviceResponseModel response)
		{
			var request = new ApiDeviceRequestModel();
			request.SetProperties(
				response.Name,
				response.PublicId);
			return request;
		}

		public JsonPatchDocument<ApiDeviceRequestModel> CreatePatch(ApiDeviceRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PublicId, model.PublicId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>850066b685532ba197ab3f406162785d</Hash>
</Codenesium>*/