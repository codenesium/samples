using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLTicketStatusMapper
        {
                BOTicketStatus MapModelToBO(
                        int id,
                        ApiTicketStatusRequestModel model);

                ApiTicketStatusResponseModel MapBOToModel(
                        BOTicketStatus boTicketStatus);

                List<ApiTicketStatusResponseModel> MapBOToModel(
                        List<BOTicketStatus> items);
        }
}

/*<Codenesium>
    <Hash>6127969c56528b9ee22bae7dc1503dd4</Hash>
</Codenesium>*/