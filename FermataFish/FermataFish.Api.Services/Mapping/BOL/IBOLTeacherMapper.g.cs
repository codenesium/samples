using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLTeacherMapper
        {
                BOTeacher MapModelToBO(
                        int id,
                        ApiTeacherRequestModel model);

                ApiTeacherResponseModel MapBOToModel(
                        BOTeacher boTeacher);

                List<ApiTeacherResponseModel> MapBOToModel(
                        List<BOTeacher> items);
        }
}

/*<Codenesium>
    <Hash>44adb18931a977c2d74ef9d30deb1a05</Hash>
</Codenesium>*/