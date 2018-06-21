using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public interface IBOLPetMapper
        {
                BOPet MapModelToBO(
                        int id,
                        ApiPetRequestModel model);

                ApiPetResponseModel MapBOToModel(
                        BOPet boPet);

                List<ApiPetResponseModel> MapBOToModel(
                        List<BOPet> items);
        }
}

/*<Codenesium>
    <Hash>8114bde019bfd816fc99ab6f7e9db033</Hash>
</Codenesium>*/