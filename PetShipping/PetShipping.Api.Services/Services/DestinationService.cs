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
        public partial class DestinationService : AbstractDestinationService, IDestinationService
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
    <Hash>53fc6d2b5d736678e995543c76fafa1e</Hash>
</Codenesium>*/