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
        public class BusinessEntityAddressService : AbstractBusinessEntityAddressService, IBusinessEntityAddressService
        {
                public BusinessEntityAddressService(
                        ILogger<IBusinessEntityAddressRepository> logger,
                        IBusinessEntityAddressRepository businessEntityAddressRepository,
                        IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
                        IBOLBusinessEntityAddressMapper bolbusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalbusinessEntityAddressMapper
                        )
                        : base(logger,
                               businessEntityAddressRepository,
                               businessEntityAddressModelValidator,
                               bolbusinessEntityAddressMapper,
                               dalbusinessEntityAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>010fd63a1d5a8dd56f197b7b902363eb</Hash>
</Codenesium>*/