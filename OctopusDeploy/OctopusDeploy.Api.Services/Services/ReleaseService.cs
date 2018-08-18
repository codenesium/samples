using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ReleaseService : AbstractReleaseService, IReleaseService
	{
		public ReleaseService(
			ILogger<IReleaseRepository> logger,
			IReleaseRepository releaseRepository,
			IApiReleaseRequestModelValidator releaseModelValidator,
			IBOLReleaseMapper bolreleaseMapper,
			IDALReleaseMapper dalreleaseMapper
			)
			: base(logger,
			       releaseRepository,
			       releaseModelValidator,
			       bolreleaseMapper,
			       dalreleaseMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8d34657d708eda59742e032fcc6c1621</Hash>
</Codenesium>*/