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
                               dalpasswordMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b7775b77482c79e7bb331785dda9b8ce</Hash>
</Codenesium>*/