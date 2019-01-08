using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiColumnSameAsFKTableModelMapper
	{
		ApiColumnSameAsFKTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiColumnSameAsFKTableClientRequestModel request);

		ApiColumnSameAsFKTableClientRequestModel MapClientResponseToRequest(
			ApiColumnSameAsFKTableClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b8f30b7e149dd37bc2f4be7e2f4cb780</Hash>
</Codenesium>*/