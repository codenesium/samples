using Codenesium.DataConversionExtensions;
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
    <Hash>87825b45b4cd675f8f9c78f9e8f144c0</Hash>
</Codenesium>*/