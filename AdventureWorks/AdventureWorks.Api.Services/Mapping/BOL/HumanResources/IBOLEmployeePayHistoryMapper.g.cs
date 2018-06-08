using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLEmployeePayHistoryMapper
        {
                BOEmployeePayHistory MapModelToBO(
                        int businessEntityID,
                        ApiEmployeePayHistoryRequestModel model);

                ApiEmployeePayHistoryResponseModel MapBOToModel(
                        BOEmployeePayHistory boEmployeePayHistory);

                List<ApiEmployeePayHistoryResponseModel> MapBOToModel(
                        List<BOEmployeePayHistory> items);
        }
}

/*<Codenesium>
    <Hash>590b84d69a1bdaca808f77ae6cb3bcc7</Hash>
</Codenesium>*/