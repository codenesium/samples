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
    <Hash>26169029b0696d8a0ee4411c5eb58290</Hash>
</Codenesium>*/