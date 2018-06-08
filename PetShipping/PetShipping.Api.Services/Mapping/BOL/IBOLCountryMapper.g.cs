using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>4c38b86475b6917401dadc6a0d7163d1</Hash>
</Codenesium>*/