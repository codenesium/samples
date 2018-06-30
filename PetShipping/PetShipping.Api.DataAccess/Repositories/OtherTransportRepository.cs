using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class OtherTransportRepository : AbstractOtherTransportRepository, IOtherTransportRepository
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
    <Hash>9a8cb9abb1cf37f77ea5cf3b3e8dd129</Hash>
</Codenesium>*/