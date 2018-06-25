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
        public partial class BusinessEntityService : AbstractBusinessEntityService, IBusinessEntityService
        {
                public BusinessEntityService(
                        ILogger<IBusinessEntityRepository> logger,
                        IBusinessEntityRepository businessEntityRepository,
                        IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
                        IBOLBusinessEntityMapper bolbusinessEntityMapper,
                        IDALBusinessEntityMapper dalbusinessEntityMapper,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper,
                        IBOLPersonMapper bolPersonMapper,
                        IDALPersonMapper dalPersonMapper
                        )
                        : base(logger,
                               businessEntityRepository,
                               businessEntityModelValidator,
                               bolbusinessEntityMapper,
                               dalbusinessEntityMapper,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper,
                               bolPersonMapper,
                               dalPersonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a62721b6887bf85a74d41f6005bc79d9</Hash>
</Codenesium>*/