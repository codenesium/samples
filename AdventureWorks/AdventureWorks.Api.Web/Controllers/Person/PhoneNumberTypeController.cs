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
        [Route("api/phoneNumberTypes")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PhoneNumberTypeController : AbstractPhoneNumberTypeController
        {
                public PhoneNumberTypeController(
                        ApiSettings settings,
                        ILogger<PhoneNumberTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPhoneNumberTypeService phoneNumberTypeService,
                        IApiPhoneNumberTypeModelMapper phoneNumberTypeModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               phoneNumberTypeService,
                               phoneNumberTypeModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>07700ff8aa78a632aa18f8e8b36d78d3</Hash>
</Codenesium>*/