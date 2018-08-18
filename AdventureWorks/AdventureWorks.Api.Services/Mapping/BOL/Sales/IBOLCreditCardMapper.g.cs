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
    <Hash>9c0d63b565c95d4ada35a832c482a9b5</Hash>
</Codenesium>*/