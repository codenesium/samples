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
        public class MachinePolicyService : AbstractMachinePolicyService, IMachinePolicyService
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
    <Hash>2aad3cc11459ecd55b33486baa50a1f6</Hash>
</Codenesium>*/