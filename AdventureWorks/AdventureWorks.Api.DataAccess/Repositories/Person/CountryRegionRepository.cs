using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CountryRegionRepository: AbstractCountryRegionRepository, ICountryRegionRepository
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
    <Hash>ed37b3f0dc982f99353a1ef34c1aeebc</Hash>
</Codenesium>*/