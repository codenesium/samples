using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiVersionInfoModelMapper
	{
		ApiVersionInfoClientResponseModel MapClientRequestToResponse(
			long version,
			ApiVersionInfoClientRequestModel request);

		ApiVersionInfoClientRequestModel MapClientResponseToRequest(
			ApiVersionInfoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a0dd4776de380f1135ec8874df06b916</Hash>
</Codenesium>*/