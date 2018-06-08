using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLEmployeeMapper
        {
                BOEmployee MapModelToBO(
                        int businessEntityID,
                        ApiEmployeeRequestModel model);

                ApiEmployeeResponseModel MapBOToModel(
                        BOEmployee boEmployee);

                List<ApiEmployeeResponseModel> MapBOToModel(
                        List<BOEmployee> items);
        }
}

/*<Codenesium>
    <Hash>18be0627f5a8fd2200130976b1aae0b2</Hash>
</Codenesium>*/