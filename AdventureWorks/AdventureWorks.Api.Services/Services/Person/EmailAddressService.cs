using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class EmailAddressService : AbstractEmailAddressService, IEmailAddressService
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
    <Hash>eff8f12d963dec5cd940d801d727a137</Hash>
</Codenesium>*/