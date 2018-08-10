using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLPersonCreditCardMapper
	{
		BOPersonCreditCard MapModelToBO(
			int businessEntityID,
			ApiPersonCreditCardRequestModel model);

		ApiPersonCreditCardResponseModel MapBOToModel(
			BOPersonCreditCard boPersonCreditCard);

		List<ApiPersonCreditCardResponseModel> MapBOToModel(
			List<BOPersonCreditCard> items);
	}
}

/*<Codenesium>
    <Hash>93ce9c6e16c00302c2c5991edc4cabe1</Hash>
</Codenesium>*/