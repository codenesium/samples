using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmailAddressRepository : AbstractEmailAddressRepository, IEmailAddressRepository
        {
                public EmailAddressRepository(
                        ILogger<EmailAddressRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bbdf16a8a1598b44ff8404a3ebc8e7e8</Hash>
</Codenesium>*/