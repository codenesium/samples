using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>2b92acb2371e4580910e9013c8c943cf</Hash>
</Codenesium>*/