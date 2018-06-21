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
        [Route("api/certificates")]
        [ApiVersion("1.0")]
        public class CertificateController : AbstractCertificateController
        {
                public CertificateController(
                        ApiSettings settings,
                        ILogger<CertificateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICertificateService certificateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               certificateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>94bdae6bbe712146f3a33245ebf48a00</Hash>
</Codenesium>*/