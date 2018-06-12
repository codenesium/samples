using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class AccountRepository: AbstractAccountRepository, IAccountRepository
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
    <Hash>fb35495bd199852aafb5cbb3bc055874</Hash>
</Codenesium>*/