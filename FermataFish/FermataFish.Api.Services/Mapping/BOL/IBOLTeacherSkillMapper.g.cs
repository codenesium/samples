using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLTeacherSkillMapper
        {
                BOTeacherSkill MapModelToBO(
                        int id,
                        ApiTeacherSkillRequestModel model);

                ApiTeacherSkillResponseModel MapBOToModel(
                        BOTeacherSkill boTeacherSkill);

                List<ApiTeacherSkillResponseModel> MapBOToModel(
                        List<BOTeacherSkill> items);
        }
}

/*<Codenesium>
    <Hash>dcaa529ff45ac24f7584cc57dc254726</Hash>
</Codenesium>*/