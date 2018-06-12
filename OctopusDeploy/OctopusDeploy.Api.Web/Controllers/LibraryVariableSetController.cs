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
        [Route("api/libraryVariableSets")]
        [ApiVersion("1.0")]
        public class LibraryVariableSetController: AbstractLibraryVariableSetController
        {
                public LibraryVariableSetController(
                        ServiceSettings settings,
                        ILogger<LibraryVariableSetController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILibraryVariableSetService libraryVariableSetService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               libraryVariableSetService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ba5e4626f4c85c7c0ced411e3cf66466</Hash>
</Codenesium>*/