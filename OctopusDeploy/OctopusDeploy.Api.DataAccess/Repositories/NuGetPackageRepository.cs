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
    <Hash>832a03c9c8740ca1a5ef7bbd57d7c2fe</Hash>
</Codenesium>*/