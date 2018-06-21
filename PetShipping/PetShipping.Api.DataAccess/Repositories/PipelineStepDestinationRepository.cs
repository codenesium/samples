using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepDestinationRepository : AbstractPipelineStepDestinationRepository, IPipelineStepDestinationRepository
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
    <Hash>0e5860a7c314a1c06d4231eae0a7ecbb</Hash>
</Codenesium>*/