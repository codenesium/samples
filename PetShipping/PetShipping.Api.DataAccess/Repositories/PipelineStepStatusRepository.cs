using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStepStatusRepository : AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
        {
                public PipelineStepStatusRepository(
                        ILogger<PipelineStepStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>15165d7d31de90943994aea88a90ae45</Hash>
</Codenesium>*/