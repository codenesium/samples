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
        [Route("api/phoneNumberTypes")]
        [ApiVersion("1.0")]
        public class PhoneNumberTypeController: AbstractPhoneNumberTypeController
        {
                public PhoneNumberTypeController(
                        ServiceSettings settings,
                        ILogger<PhoneNumberTypeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPhoneNumberTypeService phoneNumberTypeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               phoneNumberTypeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>219948105159cc3b3a6196c12e181bb5</Hash>
</Codenesium>*/