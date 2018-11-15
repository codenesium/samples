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
			ApiCountryRegionServerRequestModel model);

		ApiCountryRegionServerResponseModel MapBOToModel(
			BOCountryRegion boCountryRegion);

		List<ApiCountryRegionServerResponseModel> MapBOToModel(
			List<BOCountryRegion> items);
	}
}

/*<Codenesium>
    <Hash>a96692e83c0992a2ca341882358159cf</Hash>
</Codenesium>*/