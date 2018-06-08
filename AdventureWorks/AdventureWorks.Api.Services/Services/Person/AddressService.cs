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
        public class AddressService: AbstractAddressService, IAddressService
        {
                public AddressService(
                        ILogger<AddressRepository> logger,
                        IAddressRepository addressRepository,
                        IApiAddressRequestModelValidator addressModelValidator,
                        IBOLAddressMapper boladdressMapper,
                        IDALAddressMapper daladdressMapper)
                        : base(logger,
                               addressRepository,
                               addressModelValidator,
                               boladdressMapper,
                               daladdressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c0b85879770178c5ff13861f2810cc9a</Hash>
</Codenesium>*/