using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>172daf9fb47200dce078c6109fa733ab</Hash>
</Codenesium>*/