using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ecab9e9a6190f382052a4d9d76821e53</Hash>
</Codenesium>*/