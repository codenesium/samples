using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
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
    <Hash>59ad3badff4b8b347c2f192ae1ada1ed</Hash>
</Codenesium>*/