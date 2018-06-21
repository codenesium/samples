using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AddressTypeRepository : AbstractAddressTypeRepository, IAddressTypeRepository
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
    <Hash>8a6cb4f41779a454d4b95a5129e7b7c3</Hash>
</Codenesium>*/