using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiDocumentModelMapper
	{
		ApiDocumentResponseModel MapRequestToResponse(
			Guid rowguid,
			ApiDocumentRequestModel request);

		ApiDocumentRequestModel MapResponseToRequest(
			ApiDocumentResponseModel response);

		JsonPatchDocument<ApiDocumentRequestModel> CreatePatch(ApiDocumentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bfa4b80d37618720c83cbefb0ef099cd</Hash>
</Codenesium>*/