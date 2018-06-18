using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/unitMeasures")]
        [ApiVersion("1.0")]
        public class UnitMeasureController: AbstractUnitMeasureController
        {
                public UnitMeasureController(
                        ApiSettings settings,
                        ILogger<UnitMeasureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IUnitMeasureService unitMeasureService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               unitMeasureService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1cbec24fd762b15ea4e626ef3d8b39b1</Hash>
</Codenesium>*/