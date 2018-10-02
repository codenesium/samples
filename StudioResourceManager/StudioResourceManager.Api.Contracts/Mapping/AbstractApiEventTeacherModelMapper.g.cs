using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventTeacherModelMapper
	{
		public virtual ApiEventTeacherResponseModel MapRequestToResponse(
			int id,
			ApiEventTeacherRequestModel request)
		{
			var response = new ApiEventTeacherResponseModel();
			response.SetProperties(id,
			                       request.EventId);
			return response;
		}

		public virtual ApiEventTeacherRequestModel MapResponseToRequest(
			ApiEventTeacherResponseModel response)
		{
			var request = new ApiEventTeacherRequestModel();
			request.SetProperties(
				response.EventId);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherRequestModel> CreatePatch(ApiEventTeacherRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9fd1e8cec7eca5ed7400d7de41569bda</Hash>
</Codenesium>*/