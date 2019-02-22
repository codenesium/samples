using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiNoteServerModelMapper
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
    <Hash>605e8153cab2b7bb7e49637b1e6382d7</Hash>
</Codenesium>*/