using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3dcff2a861a75912ef462dddfe76fdfb</Hash>
</Codenesium>*/