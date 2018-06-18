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
                        ILogger<IAccountRepository> logger,
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
    <Hash>1c0b143b8991a2de70f84e220cf9739b</Hash>
</Codenesium>*/