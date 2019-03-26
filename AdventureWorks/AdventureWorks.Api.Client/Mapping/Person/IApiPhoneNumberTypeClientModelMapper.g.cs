using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiPhoneNumberTypeModelMapper
	{
		ApiPhoneNumberTypeClientResponseModel MapClientRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeClientRequestModel request);

		ApiPhoneNumberTypeClientRequestModel MapClientResponseToRequest(
			ApiPhoneNumberTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b169bf63cdfaa1524c5cff8755f1ada7</Hash>
</Codenesium>*/