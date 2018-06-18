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
                        ILogger<IHandlerRepository> logger,
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
    <Hash>6d545369c83a51fc3773ce801f72e739</Hash>
</Codenesium>*/