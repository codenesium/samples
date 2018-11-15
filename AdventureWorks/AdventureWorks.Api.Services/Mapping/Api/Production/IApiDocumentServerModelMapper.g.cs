using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDocumentServerModelMapper
	{
		ApiDocumentServerResponseModel MapServerRequestToResponse(
			Guid rowguid,
			ApiDocumentServerRequestModel request);

		ApiDocumentServerRequestModel MapServerResponseToRequest(
			ApiDocumentServerResponseModel response);

		ApiDocumentClientRequestModel MapServerResponseToClientRequest(
			ApiDocumentServerResponseModel response);

		JsonPatchDocument<ApiDocumentServerRequestModel> CreatePatch(ApiDocumentServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>713cc2393c9fd79878521d6e2863a657</Hash>
</Codenesium>*/