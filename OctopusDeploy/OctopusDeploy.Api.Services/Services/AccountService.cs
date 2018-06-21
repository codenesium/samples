using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class AccountService : AbstractAccountService, IAccountService
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
                               dalaccountMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2fa149e2a6f725e595d52d7a16b13207</Hash>
</Codenesium>*/