using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductModelMapper
	{
		ApiProductClientResponseModel MapClientRequestToResponse(
			int productID,
			ApiProductClientRequestModel request);

		ApiProductClientRequestModel MapClientResponseToRequest(
			ApiProductClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>96676d69b38ad0dc7ca65fbb0e476e64</Hash>
</Codenesium>*/