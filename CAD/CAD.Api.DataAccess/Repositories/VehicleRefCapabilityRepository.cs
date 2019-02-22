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
	public partial class VehicleRefCapabilityRepository : AbstractVehicleRefCapabilityRepository, IVehicleRefCapabilityRepository
	{
		public VehicleRefCapabilityRepository(
			ILogger<VehicleRefCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5580d82222ed5a1b4942f0ef170d1881</Hash>
</Codenesium>*/