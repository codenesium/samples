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
			List<BOPersonCreditCard> bos);
	}
}

/*<Codenesium>
    <Hash>38e04b278bcecc5a37813af3409ef072</Hash>
</Codenesium>*/