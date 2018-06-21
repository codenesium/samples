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
        public class HandlerService : AbstractHandlerService, IHandlerService
        {
                public HandlerService(
                        ILogger<IHandlerRepository> logger,
                        IHandlerRepository handlerRepository,
                        IApiHandlerRequestModelValidator handlerModelValidator,
                        IBOLHandlerMapper bolhandlerMapper,
                        IDALHandlerMapper dalhandlerMapper,
                        IBOLAirTransportMapper bolAirTransportMapper,
                        IDALAirTransportMapper dalAirTransportMapper,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper
                        )
                        : base(logger,
                               handlerRepository,
                               handlerModelValidator,
                               bolhandlerMapper,
                               dalhandlerMapper,
                               bolAirTransportMapper,
                               dalAirTransportMapper,
                               bolHandlerPipelineStepMapper,
                               dalHandlerPipelineStepMapper,
                               bolOtherTransportMapper,
                               dalOtherTransportMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a0d1db5463f69a27676f731390457a02</Hash>
</Codenesium>*/