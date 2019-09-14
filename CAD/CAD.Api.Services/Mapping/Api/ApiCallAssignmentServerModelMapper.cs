using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallAssignmentServerModelMapper : IApiCallAssignmentServerModelMapper
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
    <Hash>02d5d7b0bfe3854a6a3066092c19ac37</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/