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
        public class PipelineService: AbstractPipelineService, IPipelineService
        {
                public PipelineService(
                        ILogger<IPipelineRepository> logger,
                        IPipelineRepository pipelineRepository,
                        IApiPipelineRequestModelValidator pipelineModelValidator,
                        IBOLPipelineMapper bolpipelineMapper,
                        IDALPipelineMapper dalpipelineMapper

                        )
                        : base(logger,
                               pipelineRepository,
                               pipelineModelValidator,
                               bolpipelineMapper,
                               dalpipelineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e6d30af4c5292f112645cdd1a20a3388</Hash>
</Codenesium>*/