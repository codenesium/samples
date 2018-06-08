using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class DestinationRepository: AbstractDestinationRepository, IDestinationRepository
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
    <Hash>0034c32ef30f1fee9986d7959705385d</Hash>
</Codenesium>*/