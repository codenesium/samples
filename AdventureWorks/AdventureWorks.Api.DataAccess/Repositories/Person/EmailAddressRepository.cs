using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class EmailAddressRepository : AbstractEmailAddressRepository, IEmailAddressRepository
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
    <Hash>41905dc4b7cd845d18a3bc474dd6cea1</Hash>
</Codenesium>*/