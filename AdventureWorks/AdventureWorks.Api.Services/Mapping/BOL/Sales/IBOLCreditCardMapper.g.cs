using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCreditCardMapper
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
    <Hash>f53d2202fe43410b26777c4f18822978</Hash>
</Codenesium>*/