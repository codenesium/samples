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
    <Hash>71320adbe8895918f980905e8677598a</Hash>
</Codenesium>*/