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
                        IDALPipelineStepStatusMapper dalpipelineStepStatusMapper
                        ,
                        IBOLPipelineStepMapper bolPipelineStepMapper,
                        IDALPipelineStepMapper dalPipelineStepMapper

                        )
                        : base(logger,
                               pipelineStepStatusRepository,
                               pipelineStepStatusModelValidator,
                               bolpipelineStepStatusMapper,
                               dalpipelineStepStatusMapper
                               ,
                               bolPipelineStepMapper,
                               dalPipelineStepMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b8753f33c1dbdda00a155117bc17792c</Hash>
</Codenesium>*/