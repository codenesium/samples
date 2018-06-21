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
        public class AddressService : AbstractAddressService, IAddressService
        {
                public AddressService(
                        ILogger<IAddressRepository> logger,
                        IAddressRepository addressRepository,
                        IApiAddressRequestModelValidator addressModelValidator,
                        IBOLAddressMapper boladdressMapper,
                        IDALAddressMapper daladdressMapper,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
                        )
                        : base(logger,
                               addressRepository,
                               addressModelValidator,
                               boladdressMapper,
                               daladdressMapper,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1a1853b413b87a181c9bc84f8a7beab2</Hash>
</Codenesium>*/