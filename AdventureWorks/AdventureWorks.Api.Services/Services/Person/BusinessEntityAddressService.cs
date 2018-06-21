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
    <Hash>430962e3310532661c82e0a388dfe672</Hash>
</Codenesium>*/