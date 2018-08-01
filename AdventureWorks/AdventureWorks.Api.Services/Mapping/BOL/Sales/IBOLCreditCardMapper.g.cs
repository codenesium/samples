using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>6de23c65151e19405f7a849a1d2fc1e2</Hash>
</Codenesium>*/