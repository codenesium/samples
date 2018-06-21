using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepStatusRepository : AbstractPipelineStepStatusRepository, IPipelineStepStatusRepository
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
    <Hash>2da3a9f19c2de1f77f466b1a0d95387e</Hash>
</Codenesium>*/