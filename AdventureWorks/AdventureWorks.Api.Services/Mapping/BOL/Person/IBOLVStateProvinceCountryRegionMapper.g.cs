using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLVStateProvinceCountryRegionMapper
	{
		BOVStateProvinceCountryRegion MapModelToBO(
			int stateProvinceID,
			ApiVStateProvinceCountryRegionRequestModel model);

		ApiVStateProvinceCountryRegionResponseModel MapBOToModel(
			BOVStateProvinceCountryRegion boVStateProvinceCountryRegion);

		List<ApiVStateProvinceCountryRegionResponseModel> MapBOToModel(
			List<BOVStateProvinceCountryRegion> items);
	}
}

/*<Codenesium>
    <Hash>6460465e191bcfe34762220e6bf21655</Hash>
</Codenesium>*/