using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSpecialOfferModelMapper
	{
		ApiSpecialOfferClientResponseModel MapClientRequestToResponse(
			int specialOfferID,
			ApiSpecialOfferClientRequestModel request);

		ApiSpecialOfferClientRequestModel MapClientResponseToRequest(
			ApiSpecialOfferClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c70dcd3392f3afc8f6fbcbf690057de5</Hash>
</Codenesium>*/