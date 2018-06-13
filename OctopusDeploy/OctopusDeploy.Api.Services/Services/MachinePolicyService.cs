using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class MachinePolicyService: AbstractMachinePolicyService, IMachinePolicyService
        {
                public MachinePolicyService(
                        ILogger<MachinePolicyRepository> logger,
                        IMachinePolicyRepository machinePolicyRepository,
                        IApiMachinePolicyRequestModelValidator machinePolicyModelValidator,
                        IBOLMachinePolicyMapper bolmachinePolicyMapper,
                        IDALMachinePolicyMapper dalmachinePolicyMapper

                        )
                        : base(logger,
                               machinePolicyRepository,
                               machinePolicyModelValidator,
                               bolmachinePolicyMapper,
                               dalmachinePolicyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a7961a38719629a9ed145c0ccea016c2</Hash>
</Codenesium>*/