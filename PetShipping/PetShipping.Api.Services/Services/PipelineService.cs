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
        public class PipelineService : AbstractPipelineService, IPipelineService
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
                               dalpipelineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d74ef03b4f8718c78f857a9517b8c909</Hash>
</Codenesium>*/