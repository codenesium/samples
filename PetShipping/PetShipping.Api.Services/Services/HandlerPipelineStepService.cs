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
        public class HandlerPipelineStepService : AbstractHandlerPipelineStepService, IHandlerPipelineStepService
        {
                public HandlerPipelineStepService(
                        ILogger<IHandlerPipelineStepRepository> logger,
                        IHandlerPipelineStepRepository handlerPipelineStepRepository,
                        IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
                        IBOLHandlerPipelineStepMapper bolhandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalhandlerPipelineStepMapper
                        )
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
    <Hash>90036833c428e5cc9e843f18f1b7b57a</Hash>
</Codenesium>*/