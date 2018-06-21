using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class CountryRegionRepository : AbstractCountryRegionRepository, ICountryRegionRepository
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
    <Hash>157ddf984fc23cb422cc6ac982eed89a</Hash>
</Codenesium>*/