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
	public partial class VehicleCapabilityRepository : AbstractVehicleCapabilityRepository, IVehicleCapabilityRepository
	{
		public VehicleCapabilityRepository(
			ILogger<VehicleCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>633ed11e7e16d93a4b4d7bf5585b0148</Hash>
</Codenesium>*/