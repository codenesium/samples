using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class AccountService: AbstractAccountService, IAccountService
        {
                public AccountService(
                        ILogger<AccountRepository> logger,
                        IAccountRepository accountRepository,
                        IApiAccountRequestModelValidator accountModelValidator,
                        IBOLAccountMapper bolaccountMapper,
                        IDALAccountMapper dalaccountMapper

                        )
                        : base(logger,
                               accountRepository,
                               accountModelValidator,
                               bolaccountMapper,
                               dalaccountMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d944e5ec2782dce7f44efa394de33eb8</Hash>
</Codenesium>*/