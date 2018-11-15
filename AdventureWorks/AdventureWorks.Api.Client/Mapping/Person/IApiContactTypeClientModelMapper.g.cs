using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiContactTypeModelMapper
	{
		ApiContactTypeClientResponseModel MapClientRequestToResponse(
			int contactTypeID,
			ApiContactTypeClientRequestModel request);

		ApiContactTypeClientRequestModel MapClientResponseToRequest(
			ApiContactTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5380512714be91a3c9adee14c69ff787</Hash>
</Codenesium>*/