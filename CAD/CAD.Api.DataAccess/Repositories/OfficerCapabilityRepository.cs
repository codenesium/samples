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
	public partial class OfficerCapabilityRepository : AbstractOfficerCapabilityRepository, IOfficerCapabilityRepository
	{
		public OfficerCapabilityRepository(
			ILogger<OfficerCapabilityRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>34afef60bb7a9abd4d96fb5373305a2b</Hash>
</Codenesium>*/