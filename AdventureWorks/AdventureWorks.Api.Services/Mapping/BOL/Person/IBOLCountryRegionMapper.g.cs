using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>b17f0764f188c027455585cf8a9d2ab4</Hash>
</Codenesium>*/