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
        public class PipelineStepNoteService: AbstractPipelineStepNoteService, IPipelineStepNoteService
        {
                public PipelineStepNoteService(
                        ILogger<PipelineStepNoteRepository> logger,
                        IPipelineStepNoteRepository pipelineStepNoteRepository,
                        IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
                        IBOLPipelineStepNoteMapper bolpipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalpipelineStepNoteMapper

                        )
                        : base(logger,
                               pipelineStepNoteRepository,
                               pipelineStepNoteModelValidator,
                               bolpipelineStepNoteMapper,
                               dalpipelineStepNoteMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d76cf70df89a595054c8feb61bcc7dc8</Hash>
</Codenesium>*/