using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractTeacherXTeacherSkillMapper
        {
                public virtual BOTeacherXTeacherSkill MapModelToBO(
                        int id,
                        ApiTeacherXTeacherSkillRequestModel model
                        )
                {
                        BOTeacherXTeacherSkill boTeacherXTeacherSkill = new BOTeacherXTeacherSkill();
                        boTeacherXTeacherSkill.SetProperties(
                                id,
                                model.TeacherId,
                                model.TeacherSkillId);
                        return boTeacherXTeacherSkill;
                }

                public virtual ApiTeacherXTeacherSkillResponseModel MapBOToModel(
                        BOTeacherXTeacherSkill boTeacherXTeacherSkill)
                {
                        var model = new ApiTeacherXTeacherSkillResponseModel();

                        model.SetProperties(boTeacherXTeacherSkill.Id, boTeacherXTeacherSkill.TeacherId, boTeacherXTeacherSkill.TeacherSkillId);

                        return model;
                }

                public virtual List<ApiTeacherXTeacherSkillResponseModel> MapBOToModel(
                        List<BOTeacherXTeacherSkill> items)
                {
                        List<ApiTeacherXTeacherSkillResponseModel> response = new List<ApiTeacherXTeacherSkillResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>93549d788694f85e6ccdd61e2bc16bf3</Hash>
</Codenesium>*/