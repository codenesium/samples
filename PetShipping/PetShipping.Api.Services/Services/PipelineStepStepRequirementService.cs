using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public class PipelineStepStepRequirementService : AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
        {
                public PipelineStepStepRequirementService(
                        ILogger<IPipelineStepStepRequirementRepository> logger,
                        IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
                        IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
                        IBOLPipelineStepStepRequirementMapper bolpipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalpipelineStepStepRequirementMapper
                        )
                        : base(logger,
                               pipelineStepStepRequirementRepository,
                               pipelineStepStepRequirementModelValidator,
                               bolpipelineStepStepRequirementMapper,
                               dalpipelineStepStepRequirementMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e0313141f3fc7a6c1759830aba9336e6</Hash>
</Codenesium>*/