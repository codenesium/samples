using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>cda3c94c6bd86870f490802865f03ee2</Hash>
</Codenesium>*/