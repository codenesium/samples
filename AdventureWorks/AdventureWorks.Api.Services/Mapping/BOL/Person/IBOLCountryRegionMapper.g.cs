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
			List<BOCountryRegion> bos);
	}
}

/*<Codenesium>
    <Hash>81b15c003cea6f73f1c83910cdf86d83</Hash>
</Codenesium>*/