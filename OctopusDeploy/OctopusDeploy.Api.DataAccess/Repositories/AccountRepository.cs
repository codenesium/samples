using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class AccountRepository : AbstractAccountRepository, IAccountRepository
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
    <Hash>e98e877ff642efc968fc09b220eb8f3c</Hash>
</Codenesium>*/