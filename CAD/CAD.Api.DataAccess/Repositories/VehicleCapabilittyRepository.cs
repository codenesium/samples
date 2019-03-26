using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial class VehicleCapabilittyRepository : AbstractVehicleCapabilittyRepository, IVehicleCapabilittyRepository
	{
		public VehicleCapabilittyRepository(
			ILogger<VehicleCapabilittyRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>b35e67bcd43580be2f182a7c101a4b1f</Hash>
</Codenesium>*/