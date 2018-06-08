using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>103ce53fe360d71b03c97d6fc78575e3</Hash>
</Codenesium>*/