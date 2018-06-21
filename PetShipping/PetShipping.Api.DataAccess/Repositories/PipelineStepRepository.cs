using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepRepository : AbstractPipelineStepRepository, IPipelineStepRepository
        {
                public PipelineStepRepository(
                        ILogger<PipelineStepRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e09b54e2a477cf2a2df7e7e8dfaa9e77</Hash>
</Codenesium>*/