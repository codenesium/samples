using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiNoteServerModelMapper
	{
		ApiNoteServerResponseModel MapServerRequestToResponse(
			int id,
			ApiNoteServerRequestModel request);

		ApiNoteServerRequestModel MapServerResponseToRequest(
			ApiNoteServerResponseModel response);

		ApiNoteClientRequestModel MapServerResponseToClientRequest(
			ApiNoteServerResponseModel response);

		JsonPatchDocument<ApiNoteServerRequestModel> CreatePatch(ApiNoteServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d331311962bc7bbf4912eafb84b4f6a1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/