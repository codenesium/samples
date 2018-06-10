using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class CountryRepository: AbstractCountryRepository, ICountryRepository
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
    <Hash>e9c2db26b6794d32e9a3e596b28d59b3</Hash>
</Codenesium>*/