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
	public partial class CityService : AbstractCityService, ICityService
	{
		public CityService(
			ILogger<ICityRepository> logger,
			ICityRepository cityRepository,
			IApiCityRequestModelValidator cityModelValidator,
			IBOLCityMapper bolcityMapper,
			IDALCityMapper dalcityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base(logger,
			       cityRepository,
			       cityModelValidator,
			       bolcityMapper,
			       dalcityMapper,
			       bolEventMapper,
			       dalEventMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e9ea7fb6cc68c5c84251073159270584</Hash>
</Codenesium>*/