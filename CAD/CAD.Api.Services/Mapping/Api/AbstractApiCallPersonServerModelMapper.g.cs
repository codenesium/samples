using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallPersonServerModelMapper
	{
		public virtual ApiCallPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallPersonServerRequestModel request)
		{
			var response = new ApiCallPersonServerResponseModel();
			response.SetProperties(id,
			                       request.Note,
			                       request.PersonId,
			                       request.PersonTypeId);
			return response;
		}

		public virtual ApiCallPersonServerRequestModel MapServerResponseToRequest(
			ApiCallPersonServerResponseModel response)
		{
			var request = new ApiCallPersonServerRequestModel();
			request.SetProperties(
				response.Note,
				response.PersonId,
				response.PersonTypeId);
			return request;
		}

		public virtual ApiCallPersonClientRequestModel MapServerResponseToClientRequest(
			ApiCallPersonServerResponseModel response)
		{
			var request = new ApiCallPersonClientRequestModel();
			request.SetProperties(
				response.Note,
				response.PersonId,
				response.PersonTypeId);
			return request;
		}

		public JsonPatchDocument<ApiCallPersonServerRequestModel> CreatePatch(ApiCallPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallPersonServerRequestModel>();
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PersonId, model.PersonId);
			patch.Replace(x => x.PersonTypeId, model.PersonTypeId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4d9691f5a0f7cbcbdf7c534b3b868c4b</Hash>
</Codenesium>*/