using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>78cc45392adb86fff0ff4ed609d7640f</Hash>
</Codenesium>*/