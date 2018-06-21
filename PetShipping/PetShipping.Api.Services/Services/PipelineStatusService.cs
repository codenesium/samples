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
        public class PipelineStatusService : AbstractPipelineStatusService, IPipelineStatusService
        {
                public PipelineStatusService(
                        ILogger<IPipelineStatusRepository> logger,
                        IPipelineStatusRepository pipelineStatusRepository,
                        IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
                        IBOLPipelineStatusMapper bolpipelineStatusMapper,
                        IDALPipelineStatusMapper dalpipelineStatusMapper,
                        IBOLPipelineMapper bolPipelineMapper,
                        IDALPipelineMapper dalPipelineMapper
                        )
                        : base(logger,
                               pipelineStatusRepository,
                               pipelineStatusModelValidator,
                               bolpipelineStatusMapper,
                               dalpipelineStatusMapper,
                               bolPipelineMapper,
                               dalPipelineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>20425173d99bbcd36e9c1c1536b48472</Hash>
</Codenesium>*/