using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiNoteModelMapper : IApiNoteModelMapper
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
    <Hash>7316f584b535151d0f56d136ff1223ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/