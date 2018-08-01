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
    <Hash>ed3f32533cffe8c4562c370deda48475</Hash>
</Codenesium>*/