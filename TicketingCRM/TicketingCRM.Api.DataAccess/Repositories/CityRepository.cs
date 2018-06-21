using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class CityRepository : AbstractCityRepository, ICityRepository
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
    <Hash>47da2a70cecfa521f17c35ad27e79b79</Hash>
</Codenesium>*/