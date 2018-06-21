using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLTeacherXTeacherSkillMapper
        {
                BOTeacherXTeacherSkill MapModelToBO(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel model);

                ApiTeacherXTeacherSkillResponseModel MapBOToModel(
                        BOTeacherXTeacherSkill boTeacherXTeacherSkill);

                List<ApiTeacherXTeacherSkillResponseModel> MapBOToModel(
                        List<BOTeacherXTeacherSkill> items);
        }
}

/*<Codenesium>
    <Hash>0fbb7555534c35adb93994fea3981ded</Hash>
</Codenesium>*/