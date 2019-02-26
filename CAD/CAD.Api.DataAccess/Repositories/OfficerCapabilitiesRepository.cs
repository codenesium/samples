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
	public partial class OfficerCapabilitiesRepository : AbstractOfficerCapabilitiesRepository, IOfficerCapabilitiesRepository
	{
		public OfficerCapabilitiesRepository(
			ILogger<OfficerCapabilitiesRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>db635eb2b8caa4d6d440471cec2b30c2</Hash>
</Codenesium>*/