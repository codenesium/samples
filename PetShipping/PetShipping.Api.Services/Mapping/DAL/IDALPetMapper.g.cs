using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>0f475c26bbdfb1fe05c12eebc1b79100</Hash>
</Codenesium>*/