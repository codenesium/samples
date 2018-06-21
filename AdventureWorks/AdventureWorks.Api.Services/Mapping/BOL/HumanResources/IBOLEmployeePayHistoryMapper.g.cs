using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>be8d34692b744aff4d1299e292320127</Hash>
</Codenesium>*/