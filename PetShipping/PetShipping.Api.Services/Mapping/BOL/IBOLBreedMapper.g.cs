using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLBreedMapper
        {
                BOBreed MapModelToBO(
                        int id,
                        ApiBreedRequestModel model);

                ApiBreedResponseModel MapBOToModel(
                        BOBreed boBreed);

                List<ApiBreedResponseModel> MapBOToModel(
                        List<BOBreed> items);
        }
}

/*<Codenesium>
    <Hash>efee6046c9938e14eb41b29587ee9684</Hash>
</Codenesium>*/