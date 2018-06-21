using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepStepRequirementRepository : AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
        {
                public PipelineStepStepRequirementRepository(
                        ILogger<PipelineStepStepRequirementRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>32012a7c07d7c7b78406264e1c5cd6d9</Hash>
</Codenesium>*/