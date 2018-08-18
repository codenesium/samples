using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolcountryMapper,
			IDALCountryMapper dalcountryMapper,
			IBOLCountryRequirementMapper bolCountryRequirementMapper,
			IDALCountryRequirementMapper dalCountryRequirementMapper,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper
			)
			: base(logger,
			       countryRepository,
			       countryModelValidator,
			       bolcountryMapper,
			       dalcountryMapper,
			       bolCountryRequirementMapper,
			       dalCountryRequirementMapper,
			       bolDestinationMapper,
			       dalDestinationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3dfc4d17159945cc68a894dfd7561682</Hash>
</Codenesium>*/