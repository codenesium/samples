using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLCountryRegionCurrencyMapper
	{
		DTOCountryRegionCurrency MapModelToDTO(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model);

		ApiCountryRegionCurrencyResponseModel MapDTOToModel(
			DTOCountryRegionCurrency dtoCountryRegionCurrency);

		List<ApiCountryRegionCurrencyResponseModel> MapDTOToModel(
			List<DTOCountryRegionCurrency> dtos);
	}
}

/*<Codenesium>
    <Hash>2b733409535846b588b0bf7cbec60b38</Hash>
</Codenesium>*/