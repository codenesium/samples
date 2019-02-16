using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class CountryRegionService : AbstractCountryRegionService, ICountryRegionService
	{
		public CountryRegionService(
			ILogger<ICountryRegionRepository> logger,
			IMediator mediator,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionServerRequestModelValidator countryRegionModelValidator,
			IDALCountryRegionMapper dalCountryRegionMapper,
			IDALStateProvinceMapper dalStateProvinceMapper)
			: base(logger,
			       mediator,
			       countryRegionRepository,
			       countryRegionModelValidator,
			       dalCountryRegionMapper,
			       dalStateProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>764691fc357bcd281271f9022fa4cbe3</Hash>
</Codenesium>*/