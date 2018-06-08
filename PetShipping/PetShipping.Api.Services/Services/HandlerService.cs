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
                        IDALHandlerMapper dalhandlerMapper)
                        : base(logger,
                               handlerRepository,
                               handlerModelValidator,
                               bolhandlerMapper,
                               dalhandlerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bf9692fc14aa118454afe67ed9abd902</Hash>
</Codenesium>*/