using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCurrencyRateMapper
	{
		DTOCurrencyRate MapModelToDTO(
			int currencyRateID,
			ApiCurrencyRateRequestModel model);

		ApiCurrencyRateResponseModel MapDTOToModel(
			DTOCurrencyRate dtoCurrencyRate);

		List<ApiCurrencyRateResponseModel> MapDTOToModel(
			List<DTOCurrencyRate> dtos);
	}
}

/*<Codenesium>
    <Hash>94600d677377ca1365c4149189a48223</Hash>
</Codenesium>*/