using Codenesium.DataConversionExtensions;
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
    <Hash>1a19f82274d134f33a27d009ab38849c</Hash>
</Codenesium>*/