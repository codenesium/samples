using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PipelineStepStepRequirementRepository: AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
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
    <Hash>9313714fa5fe66d4b30025e170a9f6db</Hash>
</Codenesium>*/