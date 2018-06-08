using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLEmployeeDepartmentHistoryMapper
        {
                BOEmployeeDepartmentHistory MapModelToBO(
                        int businessEntityID,
                        ApiEmployeeDepartmentHistoryRequestModel model);

                ApiEmployeeDepartmentHistoryResponseModel MapBOToModel(
                        BOEmployeeDepartmentHistory boEmployeeDepartmentHistory);

                List<ApiEmployeeDepartmentHistoryResponseModel> MapBOToModel(
                        List<BOEmployeeDepartmentHistory> items);
        }
}

/*<Codenesium>
    <Hash>896252286b71b1a48a652a05bfcc903f</Hash>
</Codenesium>*/