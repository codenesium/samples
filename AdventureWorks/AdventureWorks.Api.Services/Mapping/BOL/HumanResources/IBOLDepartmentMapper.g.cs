using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>c1ba42095a05eeb13ce4d2b437e7f1ce</Hash>
</Codenesium>*/