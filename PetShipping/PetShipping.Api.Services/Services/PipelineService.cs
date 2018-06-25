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
        public partial class PipelineService : AbstractPipelineService, IPipelineService
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
    <Hash>3f6a31c74e5ad95df687d1cf71395c1e</Hash>
</Codenesium>*/