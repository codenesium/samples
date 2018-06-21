using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
{
        public class BreedService : AbstractBreedService, IBreedService
        {
                public BreedService(
                        ILogger<IBreedRepository> logger,
                        IBreedRepository breedRepository,
                        IApiBreedRequestModelValidator breedModelValidator,
                        IBOLBreedMapper bolbreedMapper,
                        IDALBreedMapper dalbreedMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper
                        )
                        : base(logger,
                               breedRepository,
                               breedModelValidator,
                               bolbreedMapper,
                               dalbreedMapper,
                               bolPetMapper,
                               dalPetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f4b5739ce0df699cbe93b71becd006b1</Hash>
</Codenesium>*/