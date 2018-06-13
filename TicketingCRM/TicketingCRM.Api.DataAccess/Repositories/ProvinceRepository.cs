using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class ProvinceRepository: AbstractProvinceRepository, IProvinceRepository
        {
                public ProvinceRepository(
                        ILogger<ProvinceRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7f53dfbce84c51aca0f39705e1c0d7d0</Hash>
</Codenesium>*/