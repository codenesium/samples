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
                        ILogger<IBusinessEntityRepository> logger,
                        IBusinessEntityRepository businessEntityRepository,
                        IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
                        IBOLBusinessEntityMapper bolbusinessEntityMapper,
                        IDALBusinessEntityMapper dalbusinessEntityMapper
                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
                        ,
                        IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
                        IDALBusinessEntityContactMapper dalBusinessEntityContactMapper
                        ,
                        IBOLPersonMapper bolPersonMapper,
                        IDALPersonMapper dalPersonMapper

                        )
                        : base(logger,
                               businessEntityRepository,
                               businessEntityModelValidator,
                               bolbusinessEntityMapper,
                               dalbusinessEntityMapper
                               ,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper
                               ,
                               bolBusinessEntityContactMapper,
                               dalBusinessEntityContactMapper
                               ,
                               bolPersonMapper,
                               dalPersonMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>236437fe72848ce8e55dcd72e170e345</Hash>
</Codenesium>*/