using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>938663575ebed1db4e9dd420c5013cd3</Hash>
</Codenesium>*/