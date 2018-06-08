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
                        ILogger<PipelineRepository> logger,
                        IPipelineRepository pipelineRepository,
                        IApiPipelineRequestModelValidator pipelineModelValidator,
                        IBOLPipelineMapper bolpipelineMapper,
                        IDALPipelineMapper dalpipelineMapper)
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
    <Hash>c2f235676dddcf188175fcee014e3632</Hash>
</Codenesium>*/