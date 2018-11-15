using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiVendorModelMapper
	{
		ApiVendorClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiVendorClientRequestModel request);

		ApiVendorClientRequestModel MapClientResponseToRequest(
			ApiVendorClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>65a58d227e26c585852a76422d61bc2b</Hash>
</Codenesium>*/