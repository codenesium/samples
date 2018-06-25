using Codenesium.DataConversionExtensions;
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
        public partial class AccountService : AbstractAccountService, IAccountService
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
    <Hash>bce7b7c9d4a5928737e9a18940c840f4</Hash>
</Codenesium>*/