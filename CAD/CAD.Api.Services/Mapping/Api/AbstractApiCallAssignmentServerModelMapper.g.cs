using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallAssignmentServerModelMapper
	{
		public virtual ApiCallAssignmentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallAssignmentServerRequestModel request)
		{
			var response = new ApiCallAssignmentServerResponseModel();
			response.SetProperties(id,
			                       request.CallId,
			                       request.UnitId);
			return response;
		}

		public virtual ApiCallAssignmentServerRequestModel MapServerResponseToRequest(
			ApiCallAssignmentServerResponseModel response)
		{
			var request = new ApiCallAssignmentServerRequestModel();
			request.SetProperties(
				response.CallId,
				response.UnitId);
			return request;
		}

		public virtual ApiCallAssignmentClientRequestModel MapServerResponseToClientRequest(
			ApiCallAssignmentServerResponseModel response)
		{
			var request = new ApiCallAssignmentClientRequestModel();
			request.SetProperties(
				response.CallId,
				response.UnitId);
			return request;
		}

		public JsonPatchDocument<ApiCallAssignmentServerRequestModel> CreatePatch(ApiCallAssignmentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallAssignmentServerRequestModel>();
			patch.Replace(x => x.CallId, model.CallId);
			patch.Replace(x => x.UnitId, model.UnitId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7ab77d7cf6409c222f6ebc55d3320d84</Hash>
</Codenesium>*/