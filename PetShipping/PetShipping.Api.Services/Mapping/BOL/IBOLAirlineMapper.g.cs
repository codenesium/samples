using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>62e2126e2162a038622656e6996b9db4</Hash>
</Codenesium>*/