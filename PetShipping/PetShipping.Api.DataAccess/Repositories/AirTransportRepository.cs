using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class AirTransportRepository : AbstractAirTransportRepository, IAirTransportRepository
	{
		public AirTransportRepository(
			ILogger<AirTransportRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5b94946ff723e284af07af46753ec036</Hash>
</Codenesium>*/