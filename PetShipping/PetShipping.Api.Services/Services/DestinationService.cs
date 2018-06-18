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
                        ILogger<IDestinationRepository> logger,
                        IDestinationRepository destinationRepository,
                        IApiDestinationRequestModelValidator destinationModelValidator,
                        IBOLDestinationMapper boldestinationMapper,
                        IDALDestinationMapper daldestinationMapper
                        ,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper

                        )
                        : base(logger,
                               destinationRepository,
                               destinationModelValidator,
                               boldestinationMapper,
                               daldestinationMapper
                               ,
                               bolPipelineStepDestinationMapper,
                               dalPipelineStepDestinationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>9b3f23deadbaf1520ada5e77e433f8cc</Hash>
</Codenesium>*/