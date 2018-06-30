using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>39f36620f05f1d3bfc0b266e75a56022</Hash>
</Codenesium>*/