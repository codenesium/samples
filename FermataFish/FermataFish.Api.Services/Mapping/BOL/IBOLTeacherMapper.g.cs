using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>d8c035f380581d0c3660c2695849959c</Hash>
</Codenesium>*/