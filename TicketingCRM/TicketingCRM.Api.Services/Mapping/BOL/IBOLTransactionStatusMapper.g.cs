using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLTransactionStatusMapper
        {
                BOTransactionStatus MapModelToBO(
                        int id,
                        ApiTransactionStatusRequestModel model);

                ApiTransactionStatusResponseModel MapBOToModel(
                        BOTransactionStatus boTransactionStatus);

                List<ApiTransactionStatusResponseModel> MapBOToModel(
                        List<BOTransactionStatus> items);
        }
}

/*<Codenesium>
    <Hash>dacf8ab1e9c392d2d62674c473a0c0e4</Hash>
</Codenesium>*/