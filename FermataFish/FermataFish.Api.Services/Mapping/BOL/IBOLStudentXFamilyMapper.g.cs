using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLStudentXFamilyMapper
        {
                BOStudentXFamily MapModelToBO(
                        int id,
                        ApiStudentXFamilyRequestModel model);

                ApiStudentXFamilyResponseModel MapBOToModel(
                        BOStudentXFamily boStudentXFamily);

                List<ApiStudentXFamilyResponseModel> MapBOToModel(
                        List<BOStudentXFamily> items);
        }
}

/*<Codenesium>
    <Hash>b599f2304a45caa55d472fafc60b784d</Hash>
</Codenesium>*/