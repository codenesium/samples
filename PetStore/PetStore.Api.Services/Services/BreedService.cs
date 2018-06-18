using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>90236168733a60c572595de32fad06d5</Hash>
</Codenesium>*/