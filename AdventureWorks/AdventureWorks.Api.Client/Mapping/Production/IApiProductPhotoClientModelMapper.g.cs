using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductPhotoModelMapper
	{
		ApiProductPhotoClientResponseModel MapClientRequestToResponse(
			int productPhotoID,
			ApiProductPhotoClientRequestModel request);

		ApiProductPhotoClientRequestModel MapClientResponseToRequest(
			ApiProductPhotoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c55e6d201728cdc168a4e7d8e7cf020b</Hash>
</Codenesium>*/