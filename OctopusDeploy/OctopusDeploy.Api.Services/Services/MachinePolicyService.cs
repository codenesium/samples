using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>1520f6ea14788bc6315dca2173e6f370</Hash>
</Codenesium>*/