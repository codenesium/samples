using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class ProvinceRepository : AbstractProvinceRepository, IProvinceRepository
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
    <Hash>c13f915435513bcbb14798f371636099</Hash>
</Codenesium>*/