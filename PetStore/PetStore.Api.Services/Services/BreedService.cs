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
    <Hash>3f6c6f66d99fece1427e2f4d74d2fcdb</Hash>
</Codenesium>*/