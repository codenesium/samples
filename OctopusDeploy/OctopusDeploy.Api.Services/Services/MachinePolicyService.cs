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
	public partial class MachinePolicyService : AbstractMachinePolicyService, IMachinePolicyService
	{
		public MachinePolicyService(
			ILogger<IMachinePolicyRepository> logger,
			IMachinePolicyRepository machinePolicyRepository,
			IApiMachinePolicyRequestModelValidator machinePolicyModelValidator,
			IBOLMachinePolicyMapper bolmachinePolicyMapper,
			IDALMachinePolicyMapper dalmachinePolicyMapper
			)
			: base(logger,
			       machinePolicyRepository,
			       machinePolicyModelValidator,
			       bolmachinePolicyMapper,
			       dalmachinePolicyMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>168299cd2e711cf8a4d74ae13902b3de</Hash>
</Codenesium>*/