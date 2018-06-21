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
        [ApiVersion("1.0")]
        public class BillOfMaterialsController : AbstractBillOfMaterialsController
        {
                public BillOfMaterialsController(
                        ApiSettings settings,
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
    <Hash>bf7e11e11edd098c49fcbe9103882d5a</Hash>
</Codenesium>*/