using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLAdminMapper
        {
                BOAdmin MapModelToBO(
                        int id,
                        ApiAdminRequestModel model);

                ApiAdminResponseModel MapBOToModel(
                        BOAdmin boAdmin);

                List<ApiAdminResponseModel> MapBOToModel(
                        List<BOAdmin> items);
        }
}

/*<Codenesium>
    <Hash>8520c91e4507d08e0141e8a3edd99c6a</Hash>
</Codenesium>*/