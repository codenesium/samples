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
        public partial class BusinessEntityContactService : AbstractBusinessEntityContactService, IBusinessEntityContactService
        {
                public BusinessEntityContactService(
                        ILogger<IBusinessEntityContactRepository> logger,
                        IBusinessEntityContactRepository businessEntityContactRepository,
                        IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
                        IBOLBusinessEntityContactMapper bolbusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalbusinessEntityContactMapper
                        )
                        : base(logger,
                               businessEntityContactRepository,
                               businessEntityContactModelValidator,
                               bolbusinessEntityContactMapper,
                               dalbusinessEntityContactMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4ca21f3eb31e9b5c8fb4cf0e36dad9db</Hash>
</Codenesium>*/