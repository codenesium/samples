using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class OctopusServerNodeRepository : AbstractOctopusServerNodeRepository, IOctopusServerNodeRepository
	{
		public OctopusServerNodeRepository(
			ILogger<OctopusServerNodeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fd36da8a7d5d884b7cd0accf8fae6c0f</Hash>
</Codenesium>*/