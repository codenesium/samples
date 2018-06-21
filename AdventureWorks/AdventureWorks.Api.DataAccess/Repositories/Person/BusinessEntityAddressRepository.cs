using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class BusinessEntityAddressRepository : AbstractBusinessEntityAddressRepository, IBusinessEntityAddressRepository
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
    <Hash>4a216916c14608c0f845e08639ed0c61</Hash>
</Codenesium>*/