using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLPersonCreditCardMapper
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
    <Hash>037cb806f473aec9e963ac7222a4d62e</Hash>
</Codenesium>*/