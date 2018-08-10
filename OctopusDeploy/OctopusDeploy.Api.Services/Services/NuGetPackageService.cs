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
	public partial class NuGetPackageService : AbstractNuGetPackageService, INuGetPackageService
	{
		public NuGetPackageService(
			ILogger<INuGetPackageRepository> logger,
			INuGetPackageRepository nuGetPackageRepository,
			IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator,
			IBOLNuGetPackageMapper bolnuGetPackageMapper,
			IDALNuGetPackageMapper dalnuGetPackageMapper
			)
			: base(logger,
			       nuGetPackageRepository,
			       nuGetPackageModelValidator,
			       bolnuGetPackageMapper,
			       dalnuGetPackageMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>2a204eb35b312f4b7f6f189c695fda82</Hash>
</Codenesium>*/