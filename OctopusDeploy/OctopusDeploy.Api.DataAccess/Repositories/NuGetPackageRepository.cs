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
    <Hash>1362cd5e3b5ae5fc203fc80ac4b69030</Hash>
</Codenesium>*/