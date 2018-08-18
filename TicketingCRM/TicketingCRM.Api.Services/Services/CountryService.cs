using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial class CountryService : AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<ICountryRepository> logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper bolcountryMapper,
			IDALCountryMapper dalcountryMapper,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper
			)
			: base(logger,
			       countryRepository,
			       countryModelValidator,
			       bolcountryMapper,
			       dalcountryMapper,
			       bolProvinceMapper,
			       dalProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>94ce74a6ca9ebcf61eb01b4ae07ab85e</Hash>
</Codenesium>*/