using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiNoteModelMapper
	{
		public virtual ApiNoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiNoteClientRequestModel request)
		{
			var response = new ApiNoteClientResponseModel();
			response.SetProperties(id,
			                       request.CallId,
			                       request.DateCreated,
			                       request.NoteText,
			                       request.OfficerId);
			return response;
		}

		public virtual ApiNoteClientRequestModel MapClientResponseToRequest(
			ApiNoteClientResponseModel response)
		{
			var request = new ApiNoteClientRequestModel();
			request.SetProperties(
				response.CallId,
				response.DateCreated,
				response.NoteText,
				response.OfficerId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>56c24c906801cdd8f1238ce7f78ea9ff</Hash>
</Codenesium>*/