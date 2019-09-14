using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventStudentServerModelMapper : IApiEventStudentServerModelMapper
	{
		public virtual ApiEventStudentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventStudentServerRequestModel request)
		{
			var response = new ApiEventStudentServerResponseModel();
			response.SetProperties(id,
			                       request.EventId,
			                       request.StudentId);
			return response;
		}

		public virtual ApiEventStudentServerRequestModel MapServerResponseToRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentServerRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}

		public virtual ApiEventStudentClientRequestModel MapServerResponseToClientRequest(
			ApiEventStudentServerResponseModel response)
		{
			var request = new ApiEventStudentClientRequestModel();
			request.SetProperties(
				response.EventId,
				response.StudentId);
			return request;
		}

		public JsonPatchDocument<ApiEventStudentServerRequestModel> CreatePatch(ApiEventStudentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventStudentServerRequestModel>();
			patch.Replace(x => x.EventId, model.EventId);
			patch.Replace(x => x.StudentId, model.StudentId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5def18430f79303d904b4cc6bf853f31</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/