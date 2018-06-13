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
        public class BusinessEntityAddressService: AbstractBusinessEntityAddressService, IBusinessEntityAddressService
        {
                public BusinessEntityAddressService(
                        ILogger<BusinessEntityAddressRepository> logger,
                        IBusinessEntityAddressRepository businessEntityAddressRepository,
                        IApiBusinessEntityAddressRequestModelValidator businessEntityAddressModelValidator,
                        IBOLBusinessEntityAddressMapper bolbusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalbusinessEntityAddressMapper

                        )
                        : base(logger,
                               businessEntityAddressRepository,
                               businessEntityAddressModelValidator,
                               bolbusinessEntityAddressMapper,
                               dalbusinessEntityAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f217dd384f4265a07a64348324465d7f</Hash>
</Codenesium>*/