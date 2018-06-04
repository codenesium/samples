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
			List<BOCreditCard> bos);
	}
}

/*<Codenesium>
    <Hash>1e361e7264b07938ba809db03b904eee</Hash>
</Codenesium>*/