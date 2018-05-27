using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCurrencyMapper
	{
		DTOCurrency MapModelToDTO(
			string currencyCode,
			ApiCurrencyRequestModel model);

		ApiCurrencyResponseModel MapDTOToModel(
			DTOCurrency dtoCurrency);

		List<ApiCurrencyResponseModel> MapDTOToModel(
			List<DTOCurrency> dtos);
	}
}

/*<Codenesium>
    <Hash>9e12aceb97b64f1ad9068ef320660820</Hash>
</Codenesium>*/