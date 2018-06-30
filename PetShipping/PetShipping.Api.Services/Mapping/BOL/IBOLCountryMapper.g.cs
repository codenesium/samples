using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLCountryMapper
        {
                BOCountry MapModelToBO(
                        int id,
                        ApiCountryRequestModel model);

                ApiCountryResponseModel MapBOToModel(
                        BOCountry boCountry);

                List<ApiCountryResponseModel> MapBOToModel(
                        List<BOCountry> items);
        }
}

/*<Codenesium>
    <Hash>3488af7231c594db15c2f7b0729c1225</Hash>
</Codenesium>*/