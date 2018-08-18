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
    <Hash>bd8800730f799e581dc3d294aca4cb55</Hash>
</Codenesium>*/