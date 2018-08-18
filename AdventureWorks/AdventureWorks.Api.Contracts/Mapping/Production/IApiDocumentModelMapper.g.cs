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
    <Hash>90b217c4001e0ea4952a842a935a7c7d</Hash>
</Codenesium>*/