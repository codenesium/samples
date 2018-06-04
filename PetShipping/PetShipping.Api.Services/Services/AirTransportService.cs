using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class AirTransportService: AbstractAirTransportService, IAirTransportService
	{
		public AirTransportService(
			ILogger<AirTransportRepository> logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper BOLairTransportMapper,
			IDALAirTransportMapper DALairTransportMapper)
			: base(logger, airTransportRepository,
			       airTransportModelValidator,
			       BOLairTransportMapper,
			       DALairTransportMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>6b2aaccc7a2c66142fb811b44725117e</Hash>
</Codenesium>*/