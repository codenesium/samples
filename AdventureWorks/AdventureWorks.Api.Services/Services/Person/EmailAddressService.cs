using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class EmailAddressService: AbstractEmailAddressService, IEmailAddressService
        {
                public EmailAddressService(
                        ILogger<EmailAddressRepository> logger,
                        IEmailAddressRepository emailAddressRepository,
                        IApiEmailAddressRequestModelValidator emailAddressModelValidator,
                        IBOLEmailAddressMapper bolemailAddressMapper,
                        IDALEmailAddressMapper dalemailAddressMapper)
                        : base(logger,
                               emailAddressRepository,
                               emailAddressModelValidator,
                               bolemailAddressMapper,
                               dalemailAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0d0174f3e44459506f60d2d9f1eeba36</Hash>
</Codenesium>*/