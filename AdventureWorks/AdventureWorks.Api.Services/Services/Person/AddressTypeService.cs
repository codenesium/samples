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
                        IDALAddressTypeMapper daladdressTypeMapper)
                        : base(logger,
                               addressTypeRepository,
                               addressTypeModelValidator,
                               boladdressTypeMapper,
                               daladdressTypeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4a2a868049f2e54585d630856bc89732</Hash>
</Codenesium>*/