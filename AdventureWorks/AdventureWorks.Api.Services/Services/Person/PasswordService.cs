using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class PasswordService : AbstractPasswordService, IPasswordService
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
    <Hash>2275348a57e1525cc85a553817ee57f3</Hash>
</Codenesium>*/