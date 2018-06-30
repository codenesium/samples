using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStepDestinationRepository : AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
        {
                public PipelineStepDestinationRepository(
                        ILogger<PipelineStepDestinationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7d80bcb47d03af160d0674db99c2dc1d</Hash>
</Codenesium>*/