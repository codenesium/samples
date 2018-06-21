using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>ee23b29b7342a7cd63035a726b3d88c6</Hash>
</Codenesium>*/