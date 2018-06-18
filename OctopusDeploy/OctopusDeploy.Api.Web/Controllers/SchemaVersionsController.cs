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
        [Route("api/schemaVersions")]
        [ApiVersion("1.0")]
        public class SchemaVersionsController: AbstractSchemaVersionsController
        {
                public SchemaVersionsController(
                        ApiSettings settings,
                        ILogger<SchemaVersionsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISchemaVersionsService schemaVersionsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               schemaVersionsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b40db0cc40854fdaf32a0d872c58a891</Hash>
</Codenesium>*/