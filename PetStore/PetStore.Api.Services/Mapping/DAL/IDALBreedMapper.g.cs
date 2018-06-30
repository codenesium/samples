using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public interface IDALBreedMapper
        {
                Breed MapBOToEF(
                        BOBreed bo);

                BOBreed MapEFToBO(
                        Breed efBreed);

                List<BOBreed> MapEFToBO(
                        List<Breed> records);
        }
}

/*<Codenesium>
    <Hash>3047a55d53900d9f67f847893d54ff64</Hash>
</Codenesium>*/