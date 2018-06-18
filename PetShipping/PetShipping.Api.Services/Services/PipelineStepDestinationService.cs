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
                        ILogger<IPipelineStepDestinationRepository> logger,
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
    <Hash>4b06efe506d2dc347db728e250bbccdc</Hash>
</Codenesium>*/