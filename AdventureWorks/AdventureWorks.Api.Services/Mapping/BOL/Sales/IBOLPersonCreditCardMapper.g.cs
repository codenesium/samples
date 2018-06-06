using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>c5d3af21bc7cf3e60f0cc2900ace6589</Hash>
</Codenesium>*/