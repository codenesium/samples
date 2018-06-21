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
    <Hash>948657203696b82f4b96d4dbc23def8f</Hash>
</Codenesium>*/