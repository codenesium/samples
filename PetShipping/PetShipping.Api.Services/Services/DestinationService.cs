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
        public class DestinationService : AbstractDestinationService, IDestinationService
        {
                public DestinationService(
                        ILogger<IDestinationRepository> logger,
                        IDestinationRepository destinationRepository,
                        IApiDestinationRequestModelValidator destinationModelValidator,
                        IBOLDestinationMapper boldestinationMapper,
                        IDALDestinationMapper daldestinationMapper,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper
                        )
                        : base(logger,
                               destinationRepository,
                               destinationModelValidator,
                               boldestinationMapper,
                               daldestinationMapper,
                               bolPipelineStepDestinationMapper,
                               dalPipelineStepDestinationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>572f05759b6a372a306b4e3d70e74239</Hash>
</Codenesium>*/