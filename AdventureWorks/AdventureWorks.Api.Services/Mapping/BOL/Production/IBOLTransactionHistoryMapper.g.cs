using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLTransactionHistoryMapper
        {
                BOTransactionHistory MapModelToBO(
                        int transactionID,
                        ApiTransactionHistoryRequestModel model);

                ApiTransactionHistoryResponseModel MapBOToModel(
                        BOTransactionHistory boTransactionHistory);

                List<ApiTransactionHistoryResponseModel> MapBOToModel(
                        List<BOTransactionHistory> items);
        }
}

/*<Codenesium>
    <Hash>5f00634ac6c1e501399011f02be7a1db</Hash>
</Codenesium>*/