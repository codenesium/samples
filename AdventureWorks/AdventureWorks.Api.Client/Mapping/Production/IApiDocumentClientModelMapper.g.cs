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
    <Hash>5981547c2c88e41e6345c49132c19ece</Hash>
</Codenesium>*/