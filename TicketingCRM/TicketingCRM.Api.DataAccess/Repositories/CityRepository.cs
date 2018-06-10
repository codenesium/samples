using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class CityRepository: AbstractCityRepository, ICityRepository
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
    <Hash>f2f9f756fe533966b6fbe952138ac377</Hash>
</Codenesium>*/