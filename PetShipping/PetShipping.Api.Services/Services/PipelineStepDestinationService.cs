using Codenesium.DataConversionExtensions;
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
        public partial class PipelineStepDestinationService : AbstractPipelineStepDestinationService, IPipelineStepDestinationService
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
    <Hash>a81ad37165fa6ac49b2fad33f362a37d</Hash>
</Codenesium>*/