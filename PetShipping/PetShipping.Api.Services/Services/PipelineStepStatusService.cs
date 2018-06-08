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
        public class PipelineStepStatusService: AbstractPipelineStepStatusService, IPipelineStepStatusService
        {
                public PipelineStepStatusService(
                        ILogger<PipelineStepStatusRepository> logger,
                        IPipelineStepStatusRepository pipelineStepStatusRepository,
                        IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
                        IBOLPipelineStepStatusMapper bolpipelineStepStatusMapper,
                        IDALPipelineStepStatusMapper dalpipelineStepStatusMapper)
                        : base(logger,
                               pipelineStepStatusRepository,
                               pipelineStepStatusModelValidator,
                               bolpipelineStepStatusMapper,
                               dalpipelineStepStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>94d1c69066df4a76b219e1f10be27b7e</Hash>
</Codenesium>*/