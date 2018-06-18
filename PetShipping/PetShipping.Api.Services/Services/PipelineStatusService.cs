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
                        ILogger<IPipelineStatusRepository> logger,
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
    <Hash>0a1f3733cf133fa0122f07b199fdd725</Hash>
</Codenesium>*/