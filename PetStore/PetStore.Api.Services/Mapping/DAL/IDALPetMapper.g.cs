using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>5ff64111482e47a228d726750c9e4f2d</Hash>
</Codenesium>*/