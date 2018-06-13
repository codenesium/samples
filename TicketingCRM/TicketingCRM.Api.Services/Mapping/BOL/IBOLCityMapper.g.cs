using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLCityMapper
        {
                BOCity MapModelToBO(
                        int id,
                        ApiCityRequestModel model);

                ApiCityResponseModel MapBOToModel(
                        BOCity boCity);

                List<ApiCityResponseModel> MapBOToModel(
                        List<BOCity> items);
        }
}

/*<Codenesium>
    <Hash>3fb408813f08d1af18056d877d7dfce9</Hash>
</Codenesium>*/