using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class BusinessEntityAddressRepository : AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
        {
                public BusinessEntityAddressRepository(
                        ILogger<BusinessEntityAddressRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8cf1f65ad558c1fcb94547a26ecd1585</Hash>
</Codenesium>*/