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
    <Hash>bc920f22ab8f3b38c361c4772e705d00</Hash>
</Codenesium>*/