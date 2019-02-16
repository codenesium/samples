using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiDocumentModelMapper
	{
		ApiDocumentClientResponseModel MapClientRequestToResponse(
			Guid rowguid,
			ApiDocumentClientRequestModel request);

		ApiDocumentClientRequestModel MapClientResponseToRequest(
			ApiDocumentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4d5ad42e46697d4885c6773c62e9ecfb</Hash>
</Codenesium>*/