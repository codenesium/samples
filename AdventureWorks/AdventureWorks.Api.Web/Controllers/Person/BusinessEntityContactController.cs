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
                        ServiceSettings settings,
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
    <Hash>1ce49d4bf0cd2c9b7782a06648657e3b</Hash>
</Codenesium>*/