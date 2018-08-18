using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class LifecycleRepository : AbstractLifecycleRepository, ILifecycleRepository
	{
		public LifecycleRepository(
			ILogger<LifecycleRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4a369630841719887ac57b068145eeec</Hash>
</Codenesium>*/