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
        public class PipelineStatusService: AbstractPipelineStatusService, IPipelineStatusService
        {
                public PipelineStatusService(
                        ILogger<PipelineStatusRepository> logger,
                        IPipelineStatusRepository pipelineStatusRepository,
                        IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
                        IBOLPipelineStatusMapper bolpipelineStatusMapper,
                        IDALPipelineStatusMapper dalpipelineStatusMapper
                        ,
                        IBOLPipelineMapper bolPipelineMapper,
                        IDALPipelineMapper dalPipelineMapper

                        )
                        : base(logger,
                               pipelineStatusRepository,
                               pipelineStatusModelValidator,
                               bolpipelineStatusMapper,
                               dalpipelineStatusMapper
                               ,
                               bolPipelineMapper,
                               dalPipelineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>8a630d0c6278a413d52db458f269da51</Hash>
</Codenesium>*/