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
        public partial class HandlerPipelineStepService : AbstractHandlerPipelineStepService, IHandlerPipelineStepService
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
    <Hash>0f7387e44f51160ff79e149419ae9a4b</Hash>
</Codenesium>*/