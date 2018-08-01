using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class NuGetPackageRepository : AbstractNuGetPackageRepository, INuGetPackageRepository
	{
		public NuGetPackageRepository(
			ILogger<NuGetPackageRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9bf43f52f1d3d01c60b413a22a533829</Hash>
</Codenesium>*/