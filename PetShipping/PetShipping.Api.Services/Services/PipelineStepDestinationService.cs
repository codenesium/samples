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
        public class PipelineStepDestinationService: AbstractPipelineStepDestinationService, IPipelineStepDestinationService
        {
                public PipelineStepDestinationService(
                        ILogger<PipelineStepDestinationRepository> logger,
                        IPipelineStepDestinationRepository pipelineStepDestinationRepository,
                        IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
                        IBOLPipelineStepDestinationMapper bolpipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalpipelineStepDestinationMapper

                        )
                        : base(logger,
                               pipelineStepDestinationRepository,
                               pipelineStepDestinationModelValidator,
                               bolpipelineStepDestinationMapper,
                               dalpipelineStepDestinationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>223cb8b7464167692db9ffae4dc019d3</Hash>
</Codenesium>*/