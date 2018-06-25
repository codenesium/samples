using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class AccountRepository : AbstractAccountRepository, IAccountRepository
        {
                public AccountRepository(
                        ILogger<AccountRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4f857920e908669a2d38071e4d8fb89d</Hash>
</Codenesium>*/