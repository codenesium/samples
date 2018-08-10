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
	public partial class LifecycleService : AbstractLifecycleService, ILifecycleService
	{
		public LifecycleService(
			ILogger<ILifecycleRepository> logger,
			ILifecycleRepository lifecycleRepository,
			IApiLifecycleRequestModelValidator lifecycleModelValidator,
			IBOLLifecycleMapper bollifecycleMapper,
			IDALLifecycleMapper dallifecycleMapper
			)
			: base(logger,
			       lifecycleRepository,
			       lifecycleModelValidator,
			       bollifecycleMapper,
			       dallifecycleMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5fdcafd2c092e66c2d96b959d770a3e5</Hash>
</Codenesium>*/