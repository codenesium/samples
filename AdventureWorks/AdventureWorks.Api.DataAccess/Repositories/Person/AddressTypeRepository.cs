using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AddressTypeRepository: AbstractAddressTypeRepository, IAddressTypeRepository
        {
                public AddressTypeRepository(
                        ILogger<AddressTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>be425f71214fec721125833015bcf3d1</Hash>
</Codenesium>*/