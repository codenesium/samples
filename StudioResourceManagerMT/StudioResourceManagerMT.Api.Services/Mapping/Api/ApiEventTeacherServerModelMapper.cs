using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventTeacherServerModelMapper : IApiEventTeacherServerModelMapper
	{
		public virtual ApiEventTeacherServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventTeacherServerRequestModel request)
		{
			var response = new ApiEventTeacherServerResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherServerRequestModel MapServerResponseToRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherServerRequestModel();
			request.SetProperties(
				response.EventId,
				response.TeacherId);
			return request;
		}

		public virtual ApiEventTeacherClientRequestModel MapServerResponseToClientRequest(
			ApiEventTeacherServerResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.TeacherId);
			return request;
		}

		public JsonPatchDocument<ApiEventTeacherServerRequestModel> CreatePatch(ApiEventTeacherServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventTeacherServerRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.TeacherId, model.TeacherId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>dbbd4aeee0c24865cd384414060777bd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/