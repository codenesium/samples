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
    <Hash>e4d49c297f94860eb12d665b46e5af89</Hash>
</Codenesium>*/