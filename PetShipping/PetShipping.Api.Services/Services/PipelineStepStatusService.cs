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
                        ILogger<IPipelineStepStatusRepository> logger,
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
    <Hash>5ab25a38d41fb0b78834f450a5852911</Hash>
</Codenesium>*/