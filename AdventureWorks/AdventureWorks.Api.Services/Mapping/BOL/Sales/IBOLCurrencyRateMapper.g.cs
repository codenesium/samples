using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCurrencyRateMapper
	{
		BOCurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateRequestModel model);

		ApiCurrencyRateResponseModel MapBOToModel(
			BOCurrencyRate boCurrencyRate);

		List<ApiCurrencyRateResponseModel> MapBOToModel(
			List<BOCurrencyRate> bos);
	}
}

/*<Codenesium>
    <Hash>23c6f9f60aa50ff5b2fdf0752c15b3c4</Hash>
</Codenesium>*/