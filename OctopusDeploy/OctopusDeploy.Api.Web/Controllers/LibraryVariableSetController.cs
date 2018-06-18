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
                        ApiSettings settings,
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
    <Hash>9e9eb9b2f608ab45b97652e96df13fc2</Hash>
</Codenesium>*/