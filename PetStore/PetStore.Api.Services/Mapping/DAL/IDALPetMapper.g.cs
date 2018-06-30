using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public interface IDALPetMapper
        {
                Pet MapBOToEF(
                        BOPet bo);

                BOPet MapEFToBO(
                        Pet efPet);

                List<BOPet> MapEFToBO(
                        List<Pet> records);
        }
}

/*<Codenesium>
    <Hash>6511ed0fa7ab4ed2c4d55db1d470a862</Hash>
</Codenesium>*/