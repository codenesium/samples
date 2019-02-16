using AdventureWorksNS.Api.Contracts;
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
    <Hash>b5f4b9f298da47c75b469b1d4f1623df</Hash>
</Codenesium>*/