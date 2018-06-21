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
        public class AddressTypeService : AbstractAddressTypeService, IAddressTypeService
        {
                public AddressTypeService(
                        ILogger<IAddressTypeRepository> logger,
                        IAddressTypeRepository addressTypeRepository,
                        IApiAddressTypeRequestModelValidator addressTypeModelValidator,
                        IBOLAddressTypeMapper boladdressTypeMapper,
                        IDALAddressTypeMapper daladdressTypeMapper,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper
                        )
                        : base(logger,
                               addressTypeRepository,
                               addressTypeModelValidator,
                               boladdressTypeMapper,
                               daladdressTypeMapper,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>249eeeae021d06ddb0d4cc86a2986e27</Hash>
</Codenesium>*/