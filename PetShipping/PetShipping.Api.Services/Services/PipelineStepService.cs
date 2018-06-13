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
        public class PipelineStepService: AbstractPipelineStepService, IPipelineStepService
        {
                public PipelineStepService(
                        ILogger<PipelineStepRepository> logger,
                        IPipelineStepRepository pipelineStepRepository,
                        IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
                        IBOLPipelineStepMapper bolpipelineStepMapper,
                        IDALPipelineStepMapper dalpipelineStepMapper
                        ,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper
                        ,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper
                        ,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper
                        ,
                        IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalPipelineStepNoteMapper
                        ,
                        IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper

                        )
                        : base(logger,
                               pipelineStepRepository,
                               pipelineStepModelValidator,
                               bolpipelineStepMapper,
                               dalpipelineStepMapper
                               ,
                               bolHandlerPipelineStepMapper,
                               dalHandlerPipelineStepMapper
                               ,
                               bolOtherTransportMapper,
                               dalOtherTransportMapper
                               ,
                               bolPipelineStepDestinationMapper,
                               dalPipelineStepDestinationMapper
                               ,
                               bolPipelineStepNoteMapper,
                               dalPipelineStepNoteMapper
                               ,
                               bolPipelineStepStepRequirementMapper,
                               dalPipelineStepStepRequirementMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>62b7fdcab6e33e7fc770826854949db8</Hash>
</Codenesium>*/