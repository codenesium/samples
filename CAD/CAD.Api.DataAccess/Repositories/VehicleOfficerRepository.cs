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
	public partial class VehicleOfficerRepository : AbstractVehicleOfficerRepository, IVehicleOfficerRepository
	{
		public VehicleOfficerRepository(
			ILogger<VehicleOfficerRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6c38c186f2484104ad99cae57b5bf775</Hash>
</Codenesium>*/