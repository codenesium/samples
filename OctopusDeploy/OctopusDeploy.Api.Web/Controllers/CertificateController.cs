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
        [Route("api/certificates")]
        [ApiVersion("1.0")]
        public class CertificateController: AbstractCertificateController
        {
                public CertificateController(
                        ServiceSettings settings,
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
    <Hash>f519aec8530389b2b6aab6a3bcca973d</Hash>
</Codenesium>*/