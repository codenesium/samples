using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class PasswordService : AbstractPasswordService, IPasswordService
        {
                public PasswordService(
                        ILogger<IPasswordRepository> logger,
                        IPasswordRepository passwordRepository,
                        IApiPasswordRequestModelValidator passwordModelValidator,
                        IBOLPasswordMapper bolpasswordMapper,
                        IDALPasswordMapper dalpasswordMapper
                        )
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
    <Hash>7a60f6d6c74e85aaee4e5042c69cef81</Hash>
</Codenesium>*/