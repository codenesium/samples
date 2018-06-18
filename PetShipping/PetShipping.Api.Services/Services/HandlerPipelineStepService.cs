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
                               dalhandlerPipelineStepMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>bf9d225d7c63b87e89509a3168bc37e7</Hash>
</Codenesium>*/