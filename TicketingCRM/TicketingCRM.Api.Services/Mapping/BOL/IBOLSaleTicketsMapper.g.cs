using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLSaleTicketsMapper
        {
                BOSaleTickets MapModelToBO(
                        int id,
                        ApiSaleTicketsRequestModel model);

                ApiSaleTicketsResponseModel MapBOToModel(
                        BOSaleTickets boSaleTickets);

                List<ApiSaleTicketsResponseModel> MapBOToModel(
                        List<BOSaleTickets> items);
        }
}

/*<Codenesium>
    <Hash>3ced812608cbb82ca251216ed0319569</Hash>
</Codenesium>*/