using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1c474413566ad21c9a06bc7dbecc40ba</Hash>
</Codenesium>*/