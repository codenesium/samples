using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class EmailAddressRepository: AbstractEmailAddressRepository, IEmailAddressRepository
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
    <Hash>6ca98c2ab1fc42684fe6ccdfc43ead1d</Hash>
</Codenesium>*/