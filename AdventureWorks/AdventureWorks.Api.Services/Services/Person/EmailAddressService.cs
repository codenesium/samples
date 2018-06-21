using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class EmailAddressService : AbstractEmailAddressService, IEmailAddressService
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
                               dalemailAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8421482f8e4a16d74b54acb4b026566a</Hash>
</Codenesium>*/