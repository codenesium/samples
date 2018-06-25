using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class CityRepository : AbstractCityRepository, ICityRepository
        {
                public CityRepository(
                        ILogger<CityRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2664c53db0950c0d729b961e38a7f027</Hash>
</Codenesium>*/