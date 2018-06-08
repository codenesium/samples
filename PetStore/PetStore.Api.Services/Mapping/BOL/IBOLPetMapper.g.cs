using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>67a260bf994df882bc9667b1f81eefa8</Hash>
</Codenesium>*/