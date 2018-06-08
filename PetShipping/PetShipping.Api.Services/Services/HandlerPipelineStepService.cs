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
        public class HandlerPipelineStepService: AbstractHandlerPipelineStepService, IHandlerPipelineStepService
        {
                public HandlerPipelineStepService(
                        ILogger<HandlerPipelineStepRepository> logger,
                        IHandlerPipelineStepRepository handlerPipelineStepRepository,
                        IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
                        IBOLHandlerPipelineStepMapper bolhandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalhandlerPipelineStepMapper)
                        : base(logger,
                               handlerPipelineStepRepository,
                               handlerPipelineStepModelValidator,
                               bolhandlerPipelineStepMapper,
                               dalhandlerPipelineStepMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>17fabc9e2f2c05d22d672542203dc8fa</Hash>
</Codenesium>*/