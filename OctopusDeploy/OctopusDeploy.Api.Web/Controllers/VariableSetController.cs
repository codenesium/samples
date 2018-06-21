using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/variableSets")]
        [ApiVersion("1.0")]
        public class VariableSetController : AbstractVariableSetController
        {
                public VariableSetController(
                        ApiSettings settings,
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
    <Hash>9d53618f8c7ca1fc449a63ddfc58d872</Hash>
</Codenesium>*/