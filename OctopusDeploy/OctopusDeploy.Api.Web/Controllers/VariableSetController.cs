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
    <Hash>f4f6f5b591d4b6cf60536249d72a4dbb</Hash>
</Codenesium>*/