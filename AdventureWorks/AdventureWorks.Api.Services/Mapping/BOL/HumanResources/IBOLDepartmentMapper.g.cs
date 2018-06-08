using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLDepartmentMapper
        {
                BODepartment MapModelToBO(
                        short departmentID,
                        ApiDepartmentRequestModel model);

                ApiDepartmentResponseModel MapBOToModel(
                        BODepartment boDepartment);

                List<ApiDepartmentResponseModel> MapBOToModel(
                        List<BODepartment> items);
        }
}

/*<Codenesium>
    <Hash>02bd02131f07a952658030bba6c5669b</Hash>
</Codenesium>*/