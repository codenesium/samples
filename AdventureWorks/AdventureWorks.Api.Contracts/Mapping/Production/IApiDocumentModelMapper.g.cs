using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiDocumentModelMapper
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
    <Hash>f387dcac748c0b9eb6051f295aefa28e</Hash>
</Codenesium>*/