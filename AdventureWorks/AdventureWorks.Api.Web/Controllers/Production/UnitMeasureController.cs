using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/unitMeasures")]
        [ApiVersion("1.0")]
        public class UnitMeasureController : AbstractUnitMeasureController
        {
                public UnitMeasureController(
                        ApiSettings settings,
                        ILogger<UnitMeasureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUnitMeasureService unitMeasureService,
                        IApiUnitMeasureModelMapper unitMeasureModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               unitMeasureService,
                               unitMeasureModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e7028b0e669edc727eb8c7f8fa1e2caf</Hash>
</Codenesium>*/