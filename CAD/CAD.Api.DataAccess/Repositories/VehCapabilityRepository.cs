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
	public partial class VehCapabilityRepository : AbstractVehCapabilityRepository, IVehCapabilityRepository
	{
		public VehCapabilityRepository(
			ILogger<VehCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>301d4d68d1412e78e78dd7e51d9e5fb9</Hash>
</Codenesium>*/