using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCountryRegionMapper
	{
		CountryRegion MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel model);

		ApiCountryRegionServerResponseModel MapBOToModel(
			CountryRegion item);

		List<ApiCountryRegionServerResponseModel> MapBOToModel(
			List<CountryRegion> items);
	}
}

/*<Codenesium>
    <Hash>8674be51a42e26fc9744c7582db23aac</Hash>
</Codenesium>*/