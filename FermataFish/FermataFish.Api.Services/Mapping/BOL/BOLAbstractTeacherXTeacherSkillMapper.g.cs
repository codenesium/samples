using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>b5ed238e1c07bac5b9820b0b04f5ffcd</Hash>
</Codenesium>*/