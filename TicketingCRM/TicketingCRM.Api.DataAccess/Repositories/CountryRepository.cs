using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class CountryRepository : AbstractCountryRepository, ICountryRepository
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
    <Hash>5e08fb698934e3726a56f45ba4b22539</Hash>
</Codenesium>*/