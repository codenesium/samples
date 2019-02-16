using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCreditCardMapper
	{
		CreditCard MapModelToBO(
			int creditCardID,
			ApiCreditCardServerRequestModel model);

		ApiCreditCardServerResponseModel MapBOToModel(
			CreditCard item);

		List<ApiCreditCardServerResponseModel> MapBOToModel(
			List<CreditCard> items);
	}
}

/*<Codenesium>
    <Hash>43866eeefdb98b2079226d48e55a56be</Hash>
</Codenesium>*/