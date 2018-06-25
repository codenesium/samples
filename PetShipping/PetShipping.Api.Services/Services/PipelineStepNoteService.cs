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
        public partial class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
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
    <Hash>5ec8ea6cfedbf53c7c8a05d5aacf4378</Hash>
</Codenesium>*/