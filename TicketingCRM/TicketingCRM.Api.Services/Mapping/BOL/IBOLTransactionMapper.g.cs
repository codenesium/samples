using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLTransactionMapper
        {
                BOTransaction MapModelToBO(
                        int id,
                        ApiTransactionRequestModel model);

                ApiTransactionResponseModel MapBOToModel(
                        BOTransaction boTransaction);

                List<ApiTransactionResponseModel> MapBOToModel(
                        List<BOTransaction> items);
        }
}

/*<Codenesium>
    <Hash>f965961adcef423399da5a0803a2e041</Hash>
</Codenesium>*/