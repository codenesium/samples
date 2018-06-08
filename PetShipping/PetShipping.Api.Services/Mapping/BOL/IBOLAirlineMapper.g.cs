using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLAirlineMapper
        {
                BOAirline MapModelToBO(
                        int id,
                        ApiAirlineRequestModel model);

                ApiAirlineResponseModel MapBOToModel(
                        BOAirline boAirline);

                List<ApiAirlineResponseModel> MapBOToModel(
                        List<BOAirline> items);
        }
}

/*<Codenesium>
    <Hash>b644fab4f595c36b52e52221cab46cec</Hash>
</Codenesium>*/