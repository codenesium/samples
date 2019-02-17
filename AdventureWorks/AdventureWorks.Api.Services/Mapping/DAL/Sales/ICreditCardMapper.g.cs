using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCreditCardMapper
	{
		CreditCard MapModelToEntity(
			int creditCardID,
			ApiCreditCardServerRequestModel model);

		ApiCreditCardServerResponseModel MapEntityToModel(
			CreditCard item);

		List<ApiCreditCardServerResponseModel> MapEntityToModel(
			List<CreditCard> items);
	}
}

/*<Codenesium>
    <Hash>4f79d1ea4d62d09505f9a4f57e54d125</Hash>
</Codenesium>*/