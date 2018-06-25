using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PipelineStepStepRequirementRepository : AbstractPipelineStepStepRequirementRepository, IPipelineStepStepRequirementRepository
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
    <Hash>d14fa58f2dc4ffdeea356dbe9436d29e</Hash>
</Codenesium>*/