using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class PasswordService: AbstractPasswordService, IPasswordService
        {
                public PasswordService(
                        ILogger<PasswordRepository> logger,
                        IPasswordRepository passwordRepository,
                        IApiPasswordRequestModelValidator passwordModelValidator,
                        IBOLPasswordMapper bolpasswordMapper,
                        IDALPasswordMapper dalpasswordMapper)
                        : base(logger,
                               passwordRepository,
                               passwordModelValidator,
                               bolpasswordMapper,
                               dalpasswordMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>94b984a6965c039a84433dea859f876e</Hash>
</Codenesium>*/