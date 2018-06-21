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
        public class PipelineStepStatusService : AbstractPipelineStepStatusService, IPipelineStepStatusService
        {
                public PipelineStepStatusService(
                        ILogger<IPipelineStepStatusRepository> logger,
                        IPipelineStepStatusRepository pipelineStepStatusRepository,
                        IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
                        IBOLPipelineStepStatusMapper bolpipelineStepStatusMapper,
                        IDALPipelineStepStatusMapper dalpipelineStepStatusMapper,
                        IBOLPipelineStepMapper bolPipelineStepMapper,
                        IDALPipelineStepMapper dalPipelineStepMapper
                        )
                        : base(logger,
                               pipelineStepStatusRepository,
                               pipelineStepStatusModelValidator,
                               bolpipelineStepStatusMapper,
                               dalpipelineStepStatusMapper,
                               bolPipelineStepMapper,
                               dalPipelineStepMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bc5b3c79845b685fa84be0dbadefd171</Hash>
</Codenesium>*/