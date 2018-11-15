using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCurrencyRateMapper
	{
		BOCurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model);

		ApiCurrencyRateServerResponseModel MapBOToModel(
			BOCurrencyRate boCurrencyRate);

		List<ApiCurrencyRateServerResponseModel> MapBOToModel(
			List<BOCurrencyRate> items);
	}
}

/*<Codenesium>
    <Hash>513118878b8d834b17516bb709ff7e44</Hash>
</Codenesium>*/