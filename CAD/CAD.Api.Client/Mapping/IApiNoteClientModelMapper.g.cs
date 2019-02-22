using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiNoteModelMapper
	{
		ApiNoteClientResponseModel MapClientRequestToResponse(
			int id,
			ApiNoteClientRequestModel request);

		ApiNoteClientRequestModel MapClientResponseToRequest(
			ApiNoteClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2d7746deb20b373023e2b8fe4b5c8940</Hash>
</Codenesium>*/