using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class CountryRepository : AbstractCountryRepository, ICountryRepository
        {
                public CountryRepository(
                        ILogger<CountryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>dde094f8453d16696327d035b19d6529</Hash>
</Codenesium>*/