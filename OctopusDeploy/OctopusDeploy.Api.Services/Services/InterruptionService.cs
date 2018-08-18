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
	public partial class InterruptionService : AbstractInterruptionService, IInterruptionService
	{
		public InterruptionService(
			ILogger<IInterruptionRepository> logger,
			IInterruptionRepository interruptionRepository,
			IApiInterruptionRequestModelValidator interruptionModelValidator,
			IBOLInterruptionMapper bolinterruptionMapper,
			IDALInterruptionMapper dalinterruptionMapper
			)
			: base(logger,
			       interruptionRepository,
			       interruptionModelValidator,
			       bolinterruptionMapper,
			       dalinterruptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>60e722052a6ac8b4fedc724ae79b31af</Hash>
</Codenesium>*/