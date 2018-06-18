using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class PipelineStepStepRequirementService: AbstractPipelineStepStepRequirementService, IPipelineStepStepRequirementService
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
                               dalpipelineStepStepRequirementMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>5138ea91a4e29c50c5f907db3499d5af</Hash>
</Codenesium>*/