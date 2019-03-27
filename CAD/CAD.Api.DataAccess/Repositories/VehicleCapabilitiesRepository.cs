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
	public partial class VehicleCapabilitiesRepository : AbstractVehicleCapabilitiesRepository, IVehicleCapabilitiesRepository
	{
		public VehicleCapabilitiesRepository(
			ILogger<VehicleCapabilitiesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6b1e60b18747e8092ec412cbfe79a750</Hash>
</Codenesium>*/