using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CountryRegionService : AbstractCountryRegionService, ICountryRegionService
	{
		public CountryRegionService(
			ILogger<ICountryRegionRepository> logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionServerRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper bolCountryRegionMapper,
			IDALCountryRegionMapper dalCountryRegionMapper,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper)
			: base(logger,
			       countryRegionRepository,
			       countryRegionModelValidator,
			       bolCountryRegionMapper,
			       dalCountryRegionMapper,
			       bolStateProvinceMapper,
			       dalStateProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bb524c0efb147370ea05bd606f58d4bc</Hash>
</Codenesium>*/