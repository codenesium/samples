using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public interface IBOLSpeciesMapper
        {
                BOSpecies MapModelToBO(
                        int id,
                        ApiSpeciesRequestModel model);

                ApiSpeciesResponseModel MapBOToModel(
                        BOSpecies boSpecies);

                List<ApiSpeciesResponseModel> MapBOToModel(
                        List<BOSpecies> items);
        }
}

/*<Codenesium>
    <Hash>fd6bc7057280e71353ed4bd137644ab3</Hash>
</Codenesium>*/