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
        public class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
        {
                public PipelineStepNoteService(
                        ILogger<IPipelineStepNoteRepository> logger,
                        IPipelineStepNoteRepository pipelineStepNoteRepository,
                        IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
                        IBOLPipelineStepNoteMapper bolpipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalpipelineStepNoteMapper
                        )
                        : base(logger,
                               pipelineStepNoteRepository,
                               pipelineStepNoteModelValidator,
                               bolpipelineStepNoteMapper,
                               dalpipelineStepNoteMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>55de6917153ec6157d7e0655ea86fe27</Hash>
</Codenesium>*/