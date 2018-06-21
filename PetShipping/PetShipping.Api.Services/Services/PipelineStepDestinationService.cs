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
        public class PipelineStepDestinationService : AbstractPipelineStepDestinationService, IPipelineStepDestinationService
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
                               dalpipelineStepDestinationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b5e5b3977077fbe6450f5d37423e9cc9</Hash>
</Codenesium>*/