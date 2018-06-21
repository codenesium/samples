using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>e89805239463d38e8ab91f0c3dd5af89</Hash>
</Codenesium>*/