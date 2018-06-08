using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>efb847fa9dc568e9d222fba92fe7cf75</Hash>
</Codenesium>*/