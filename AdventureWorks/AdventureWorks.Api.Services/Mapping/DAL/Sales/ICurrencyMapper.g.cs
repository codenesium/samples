using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyMapper
	{
		Currency MapModelToEntity(
			string currencyCode,
			ApiCurrencyServerRequestModel model);

		ApiCurrencyServerResponseModel MapEntityToModel(
			Currency item);

		List<ApiCurrencyServerResponseModel> MapEntityToModel(
			List<Currency> items);
	}
}

/*<Codenesium>
    <Hash>6d9626251df2b50085699b889cf8caaf</Hash>
</Codenesium>*/