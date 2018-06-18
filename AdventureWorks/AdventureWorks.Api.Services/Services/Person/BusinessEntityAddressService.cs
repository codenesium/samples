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
                               dalbusinessEntityAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>da75c822b66a706c6b63573c9f0ff44d</Hash>
</Codenesium>*/