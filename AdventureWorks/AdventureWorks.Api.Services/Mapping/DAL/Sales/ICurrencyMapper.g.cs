using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyMapper
	{
		Currency MapModelToBO(
			string currencyCode,
			ApiCurrencyServerRequestModel model);

		ApiCurrencyServerResponseModel MapBOToModel(
			Currency item);

		List<ApiCurrencyServerResponseModel> MapBOToModel(
			List<Currency> items);
	}
}

/*<Codenesium>
    <Hash>1d883fb2d6118b0979a64151998f8918</Hash>
</Codenesium>*/