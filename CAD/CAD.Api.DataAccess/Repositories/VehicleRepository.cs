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
	public partial class VehicleRepository : AbstractVehicleRepository, IVehicleRepository
	{
		public VehicleRepository(
			ILogger<VehicleRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3849d37bfc05ef82e7bf515adc408744</Hash>
</Codenesium>*/