using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCountryRegionMapper
	{
		BOCountryRegion MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionRequestModel model);

		ApiCountryRegionResponseModel MapBOToModel(
			BOCountryRegion boCountryRegion);

		List<ApiCountryRegionResponseModel> MapBOToModel(
			List<BOCountryRegion> items);
	}
}

/*<Codenesium>
    <Hash>b5dec1896e078c2e7809974c54d2c6be</Hash>
</Codenesium>*/