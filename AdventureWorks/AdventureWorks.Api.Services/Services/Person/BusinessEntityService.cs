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
        public class BusinessEntityService: AbstractBusinessEntityService, IBusinessEntityService
        {
                public BusinessEntityService(
                        ILogger<BusinessEntityRepository> logger,
                        IBusinessEntityRepository businessEntityRepository,
                        IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
                        IBOLBusinessEntityMapper bolbusinessEntityMapper,
                        IDALBusinessEntityMapper dalbusinessEntityMapper)
                        : base(logger,
                               businessEntityRepository,
                               businessEntityModelValidator,
                               bolbusinessEntityMapper,
                               dalbusinessEntityMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2805bb70ae7409201b920cf290169e23</Hash>
</Codenesium>*/