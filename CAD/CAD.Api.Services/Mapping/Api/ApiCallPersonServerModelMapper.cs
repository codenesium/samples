using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallPersonServerModelMapper : IApiCallPersonServerModelMapper
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
    <Hash>44515f699d76624bbab5ce477a87bbf4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/