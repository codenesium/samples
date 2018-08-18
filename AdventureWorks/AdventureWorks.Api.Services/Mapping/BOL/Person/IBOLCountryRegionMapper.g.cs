using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCountryRegionMapper
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
    <Hash>b76c54a37b2fe7997940d77152efdf5d</Hash>
</Codenesium>*/