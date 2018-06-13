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
        public class BreedService: AbstractBreedService, IBreedService
        {
                public BreedService(
                        ILogger<BreedRepository> logger,
                        IBreedRepository breedRepository,
                        IApiBreedRequestModelValidator breedModelValidator,
                        IBOLBreedMapper bolbreedMapper,
                        IDALBreedMapper dalbreedMapper
                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper

                        )
                        : base(logger,
                               breedRepository,
                               breedModelValidator,
                               bolbreedMapper,
                               dalbreedMapper
                               ,
                               bolPetMapper,
                               dalPetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>03938feeeb454067cdbca156df29d3ba</Hash>
</Codenesium>*/