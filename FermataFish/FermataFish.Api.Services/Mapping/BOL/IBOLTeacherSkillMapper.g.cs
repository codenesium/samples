using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>9943787c70c8704a062cccd543e122df</Hash>
</Codenesium>*/