using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>c7e5d477cdcac0297ca8531cc6067e6b</Hash>
</Codenesium>*/