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
                        ILogger<IAddressTypeRepository> logger,
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
    <Hash>ac06489ee00feb2683fc73e4b34ff080</Hash>
</Codenesium>*/