using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/variableSets")]
        [ApiVersion("1.0")]
        public class VariableSetController: AbstractVariableSetController
        {
                public VariableSetController(
                        ServiceSettings settings,
                        ILogger<VariableSetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVariableSetService variableSetService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               variableSetService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>aabccafea3cdbb19b50abe97ca59fd4a</Hash>
</Codenesium>*/