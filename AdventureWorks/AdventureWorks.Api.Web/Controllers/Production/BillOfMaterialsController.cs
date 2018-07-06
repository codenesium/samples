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
        [Route("api/billOfMaterials")]
        [ApiController]
        [ApiVersion("1.0")]
        public class BillOfMaterialsController : AbstractBillOfMaterialsController
        {
                public BillOfMaterialsController(
                        ApiSettings settings,
                        ILogger<BillOfMaterialsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBillOfMaterialsService billOfMaterialsService,
                        IApiBillOfMaterialsModelMapper billOfMaterialsModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               billOfMaterialsService,
                               billOfMaterialsModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>37c6b43655acd9985901e2d3689bdb88</Hash>
</Codenesium>*/