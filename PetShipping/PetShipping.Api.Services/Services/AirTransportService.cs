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
	public partial class AirTransportService : AbstractAirTransportService, IAirTransportService
	{
		public AirTransportService(
			ILogger<IAirTransportRepository> logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper bolairTransportMapper,
			IDALAirTransportMapper dalairTransportMapper
			)
			: base(logger,
			       airTransportRepository,
			       airTransportModelValidator,
			       bolairTransportMapper,
			       dalairTransportMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e10a303a139e3fdc62358acb53c70de5</Hash>
</Codenesium>*/