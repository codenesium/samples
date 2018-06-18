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
                        ILogger<IEmailAddressRepository> logger,
                        IEmailAddressRepository emailAddressRepository,
                        IApiEmailAddressRequestModelValidator emailAddressModelValidator,
                        IBOLEmailAddressMapper bolemailAddressMapper,
                        IDALEmailAddressMapper dalemailAddressMapper

                        )
                        : base(logger,
                               emailAddressRepository,
                               emailAddressModelValidator,
                               bolemailAddressMapper,
                               dalemailAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a7101cb51bbf54ce6821e7e53b412ba8</Hash>
</Codenesium>*/