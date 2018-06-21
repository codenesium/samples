using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class DestinationRepository : AbstractDestinationRepository, IDestinationRepository
        {
                public DestinationRepository(
                        ILogger<DestinationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>93ba81e318b21bf632291daf032d066b</Hash>
</Codenesium>*/