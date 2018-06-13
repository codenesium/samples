using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
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
    <Hash>6a09371dd2e6fff4946405fda9c7990a</Hash>
</Codenesium>*/