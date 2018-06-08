using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0515ad0091ea91cb4cd006de1160e498</Hash>
</Codenesium>*/