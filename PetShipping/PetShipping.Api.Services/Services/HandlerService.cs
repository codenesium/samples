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
        public class HandlerService: AbstractHandlerService, IHandlerService
        {
                public HandlerService(
                        ILogger<HandlerRepository> logger,
                        IHandlerRepository handlerRepository,
                        IApiHandlerRequestModelValidator handlerModelValidator,
                        IBOLHandlerMapper bolhandlerMapper,
                        IDALHandlerMapper dalhandlerMapper
                        ,
                        IBOLAirTransportMapper bolAirTransportMapper,
                        IDALAirTransportMapper dalAirTransportMapper
                        ,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper
                        ,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper

                        )
                        : base(logger,
                               handlerRepository,
                               handlerModelValidator,
                               bolhandlerMapper,
                               dalhandlerMapper
                               ,
                               bolAirTransportMapper,
                               dalAirTransportMapper
                               ,
                               bolHandlerPipelineStepMapper,
                               dalHandlerPipelineStepMapper
                               ,
                               bolOtherTransportMapper,
                               dalOtherTransportMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>4c3418ea80c75710e25517bd28eae892</Hash>
</Codenesium>*/