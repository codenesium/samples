using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLTransactionHistoryArchiveMapper
        {
                BOTransactionHistoryArchive MapModelToBO(
                        int transactionID,
                        ApiTransactionHistoryArchiveRequestModel model);

                ApiTransactionHistoryArchiveResponseModel MapBOToModel(
                        BOTransactionHistoryArchive boTransactionHistoryArchive);

                List<ApiTransactionHistoryArchiveResponseModel> MapBOToModel(
                        List<BOTransactionHistoryArchive> items);
        }
}

/*<Codenesium>
    <Hash>019a0f93703bd40ca2b7ac9dabc52d5a</Hash>
</Codenesium>*/