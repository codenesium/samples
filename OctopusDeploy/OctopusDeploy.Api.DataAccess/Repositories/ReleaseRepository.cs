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
	public partial class ReleaseRepository : AbstractReleaseRepository, IReleaseRepository
	{
		public ReleaseRepository(
			ILogger<ReleaseRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>16635ed1112ffbd76a8ed85c8bbf7305</Hash>
</Codenesium>*/