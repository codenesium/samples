using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c79d97fcfc999e8d5e662b66bee8abd4</Hash>
</Codenesium>*/