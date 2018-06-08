using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>3ca2356b47fa1860ee35af90e0b81590</Hash>
</Codenesium>*/