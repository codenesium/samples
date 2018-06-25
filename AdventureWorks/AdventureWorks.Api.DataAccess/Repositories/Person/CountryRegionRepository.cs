using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class CountryRegionRepository : AbstractCountryRegionRepository, ICountryRegionRepository
        {
                public CountryRegionRepository(
                        ILogger<CountryRegionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9cad2451014c3e1a29a87d1f63dee7ee</Hash>
</Codenesium>*/