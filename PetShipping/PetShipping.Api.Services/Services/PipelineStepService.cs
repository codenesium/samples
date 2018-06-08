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
        public class PipelineStepService: AbstractPipelineStepService, IPipelineStepService
        {
                public PipelineStepService(
                        ILogger<PipelineStepRepository> logger,
                        IPipelineStepRepository pipelineStepRepository,
                        IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
                        IBOLPipelineStepMapper bolpipelineStepMapper,
                        IDALPipelineStepMapper dalpipelineStepMapper)
                        : base(logger,
                               pipelineStepRepository,
                               pipelineStepModelValidator,
                               bolpipelineStepMapper,
                               dalpipelineStepMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0901543f7120303e8be75411a79fd64e</Hash>
</Codenesium>*/