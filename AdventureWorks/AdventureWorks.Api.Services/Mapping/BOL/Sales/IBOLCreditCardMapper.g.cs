using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCreditCardMapper
	{
		BOCreditCard MapModelToBO(
			int creditCardID,
			ApiCreditCardRequestModel model);

		ApiCreditCardResponseModel MapBOToModel(
			BOCreditCard boCreditCard);

		List<ApiCreditCardResponseModel> MapBOToModel(
			List<BOCreditCard> items);
	}
}

/*<Codenesium>
    <Hash>e43b7dd13985c9bb35e34cf6912d889f</Hash>
</Codenesium>*/