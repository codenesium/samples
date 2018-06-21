using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class OtherTransportRepository : AbstractOtherTransportRepository, IOtherTransportRepository
        {
                public OtherTransportRepository(
                        ILogger<OtherTransportRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fff4433a08df2e6885a40ec4c1e22e6b</Hash>
</Codenesium>*/