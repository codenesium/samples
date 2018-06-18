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
                        ILogger<IBreedRepository> logger,
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
    <Hash>da9a2f673a52548ffbf80ae606140429</Hash>
</Codenesium>*/