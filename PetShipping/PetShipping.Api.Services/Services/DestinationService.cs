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
        public class DestinationService: AbstractDestinationService, IDestinationService
        {
                public DestinationService(
                        ILogger<DestinationRepository> logger,
                        IDestinationRepository destinationRepository,
                        IApiDestinationRequestModelValidator destinationModelValidator,
                        IBOLDestinationMapper boldestinationMapper,
                        IDALDestinationMapper daldestinationMapper)
                        : base(logger,
                               destinationRepository,
                               destinationModelValidator,
                               boldestinationMapper,
                               daldestinationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c77c92b4c1b6cc15546cf4311ce37431</Hash>
</Codenesium>*/