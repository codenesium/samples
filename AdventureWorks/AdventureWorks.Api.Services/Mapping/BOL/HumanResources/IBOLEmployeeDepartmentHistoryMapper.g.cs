using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a82a1d326ca242918d9edcf291f1e0ee</Hash>
</Codenesium>*/