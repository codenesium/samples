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
        public class PipelineStepService : AbstractPipelineStepService, IPipelineStepService
        {
                public PipelineStepService(
                        ILogger<IPipelineStepRepository> logger,
                        IPipelineStepRepository pipelineStepRepository,
                        IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
                        IBOLPipelineStepMapper bolpipelineStepMapper,
                        IDALPipelineStepMapper dalpipelineStepMapper,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
                        IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
                        IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper
                        )
                        : base(logger,
                               pipelineStepRepository,
                               pipelineStepModelValidator,
                               bolpipelineStepMapper,
                               dalpipelineStepMapper,
                               bolHandlerPipelineStepMapper,
                               dalHandlerPipelineStepMapper,
                               bolOtherTransportMapper,
                               dalOtherTransportMapper,
                               bolPipelineStepDestinationMapper,
                               dalPipelineStepDestinationMapper,
                               bolPipelineStepNoteMapper,
                               dalPipelineStepNoteMapper,
                               bolPipelineStepStepRequirementMapper,
                               dalPipelineStepStepRequirementMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0abe6ea4bc26bbc980dce279129543df</Hash>
</Codenesium>*/