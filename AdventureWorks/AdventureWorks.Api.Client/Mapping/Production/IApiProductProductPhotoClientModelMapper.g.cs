using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductProductPhotoModelMapper
	{
		ApiProductProductPhotoClientResponseModel MapClientRequestToResponse(
			int productID,
			ApiProductProductPhotoClientRequestModel request);

		ApiProductProductPhotoClientRequestModel MapClientResponseToRequest(
			ApiProductProductPhotoClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>923d3120308c19579538101a9cd49b2d</Hash>
</Codenesium>*/