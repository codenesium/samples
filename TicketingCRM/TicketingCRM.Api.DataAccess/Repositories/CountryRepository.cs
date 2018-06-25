using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
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
    <Hash>302cfe479900f3554dd11ab948cd35ea</Hash>
</Codenesium>*/