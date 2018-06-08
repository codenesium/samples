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
                        IDALPipelineStatusMapper dalpipelineStatusMapper)
                        : base(logger,
                               pipelineStatusRepository,
                               pipelineStatusModelValidator,
                               bolpipelineStatusMapper,
                               dalpipelineStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c5a0eab98cb2ee979aa84590366e7341</Hash>
</Codenesium>*/