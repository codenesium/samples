using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLTicketMapper
        {
                BOTicket MapModelToBO(
                        int id,
                        ApiTicketRequestModel model);

                ApiTicketResponseModel MapBOToModel(
                        BOTicket boTicket);

                List<ApiTicketResponseModel> MapBOToModel(
                        List<BOTicket> items);
        }
}

/*<Codenesium>
    <Hash>5e3aa737fc208ae456f89d995926bfb3</Hash>
</Codenesium>*/