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
    <Hash>5c3ba9698b936609b83c5f45ef3e12b5</Hash>
</Codenesium>*/