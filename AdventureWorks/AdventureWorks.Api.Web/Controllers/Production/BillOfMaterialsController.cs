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
        [Route("api/billOfMaterials")]
        [ApiVersion("1.0")]
        public class BillOfMaterialsController: AbstractBillOfMaterialsController
        {
                public BillOfMaterialsController(
                        ServiceSettings settings,
                        ILogger<BillOfMaterialsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBillOfMaterialsService billOfMaterialsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               billOfMaterialsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a18c4d9572df6d8fff2bf29a5d5f6731</Hash>
</Codenesium>*/