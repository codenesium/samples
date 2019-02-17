using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCountryRegionMapper
	{
		CountryRegion MapModelToEntity(
			string countryRegionCode,
			ApiCountryRegionServerRequestModel model);

		ApiCountryRegionServerResponseModel MapEntityToModel(
			CountryRegion item);

		List<ApiCountryRegionServerResponseModel> MapEntityToModel(
			List<CountryRegion> items);
	}
}

/*<Codenesium>
    <Hash>f610446751e9bf365f68bbc089771a3a</Hash>
</Codenesium>*/