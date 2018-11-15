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
			ApiCreditCardServerRequestModel model);

		ApiCreditCardServerResponseModel MapBOToModel(
			BOCreditCard boCreditCard);

		List<ApiCreditCardServerResponseModel> MapBOToModel(
			List<BOCreditCard> items);
	}
}

/*<Codenesium>
    <Hash>9b3175b71c018e131d85ed176f655d83</Hash>
</Codenesium>*/