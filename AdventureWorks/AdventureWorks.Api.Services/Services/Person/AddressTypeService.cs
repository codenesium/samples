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
        public class AddressTypeService: AbstractAddressTypeService, IAddressTypeService
        {
                public AddressTypeService(
                        ILogger<AddressTypeRepository> logger,
                        IAddressTypeRepository addressTypeRepository,
                        IApiAddressTypeRequestModelValidator addressTypeModelValidator,
                        IBOLAddressTypeMapper boladdressTypeMapper,
                        IDALAddressTypeMapper daladdressTypeMapper
                        ,
                        IBOLBusinessEntityAddressMapper bolBusinessEntityAddressMapper,
                        IDALBusinessEntityAddressMapper dalBusinessEntityAddressMapper

                        )
                        : base(logger,
                               addressTypeRepository,
                               addressTypeModelValidator,
                               boladdressTypeMapper,
                               daladdressTypeMapper
                               ,
                               bolBusinessEntityAddressMapper,
                               dalBusinessEntityAddressMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b9cb4a65fa6cf78ef611efb6f5de97ad</Hash>
</Codenesium>*/