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
    <Hash>1c24c78f7c98f41bebb1d8899199f627</Hash>
</Codenesium>*/