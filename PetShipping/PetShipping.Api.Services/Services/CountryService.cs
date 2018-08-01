using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>6d53d0202c73ba511ab75b9a32438e4a</Hash>
</Codenesium>*/