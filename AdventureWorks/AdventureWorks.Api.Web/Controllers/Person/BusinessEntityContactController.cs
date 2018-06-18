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
        [Route("api/businessEntityContacts")]
        [ApiVersion("1.0")]
        public class BusinessEntityContactController: AbstractBusinessEntityContactController
        {
                public BusinessEntityContactController(
                        ApiSettings settings,
                        ILogger<BusinessEntityContactController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBusinessEntityContactService businessEntityContactService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               businessEntityContactService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>8f28750122a64a41cea9be06783d46f5</Hash>
</Codenesium>*/