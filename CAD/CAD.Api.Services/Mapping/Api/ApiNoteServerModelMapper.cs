using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiNoteServerModelMapper : IApiNoteServerModelMapper
	{
		public virtual ApiNoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiNoteServerRequestModel request)
		{
			var response = new ApiNoteServerResponseModel();
			response.SetProperties(id,
			                       request.CallId,
			                       request.DateCreated,
			                       request.NoteText,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiNoteServerRequestModel MapServerResponseToRequest(
			ApiNoteServerResponseModel response)
		{
			var request = new ApiNoteServerRequestModel();
			request.SetProperties(
				response.CallId,
				response.DateCreated,
				response.NoteText,
				response.OfficerId);
			return request;
		}

		public virtual ApiNoteClientRequestModel MapServerResponseToClientRequest(
			ApiNoteServerResponseModel response)
		{
			var request = new ApiNoteClientRequestModel();
			request.SetProperties(
				response.CallId,
				response.DateCreated,
				response.NoteText,
				response.OfficerId);
			return request;
		}

		public JsonPatchDocument<ApiNoteServerRequestModel> CreatePatch(ApiNoteServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiNoteServerRequestModel>();
			patch.Replace(x => x.CallId, model.CallId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.NoteText, model.NoteText);
			patch.Replace(x => x.OfficerId, model.OfficerId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>caa38ab6736fffae70c427f544070e14</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/