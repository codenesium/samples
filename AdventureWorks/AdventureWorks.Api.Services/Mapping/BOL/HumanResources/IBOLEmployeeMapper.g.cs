using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2612d53b481a70bddc7cb438a97e1d18</Hash>
</Codenesium>*/