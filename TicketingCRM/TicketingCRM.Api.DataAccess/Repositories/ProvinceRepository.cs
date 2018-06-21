using Codenesium.DataConversionExtensions;
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
    <Hash>f886e16652eb36d77c426d10757080fb</Hash>
</Codenesium>*/