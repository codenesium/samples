using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class ProvinceRepository : AbstractProvinceRepository, IProvinceRepository
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
    <Hash>e9b8e23da1e26559944ec8a2f4d7b785</Hash>
</Codenesium>*/