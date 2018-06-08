using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractTeacherSkillMapper
        {
                public virtual BOTeacherSkill MapModelToBO(
                        int id,
                        ApiTeacherSkillRequestModel model
                        )
                {
                        BOTeacherSkill boTeacherSkill = new BOTeacherSkill();

                        boTeacherSkill.SetProperties(
                                id,
                                model.Name,
                                model.StudioId);
                        return boTeacherSkill;
                }

                public virtual ApiTeacherSkillResponseModel MapBOToModel(
                        BOTeacherSkill boTeacherSkill)
                {
                        var model = new ApiTeacherSkillResponseModel();

                        model.SetProperties(boTeacherSkill.Id, boTeacherSkill.Name, boTeacherSkill.StudioId);

                        return model;
                }

                public virtual List<ApiTeacherSkillResponseModel> MapBOToModel(
                        List<BOTeacherSkill> items)
                {
                        List<ApiTeacherSkillResponseModel> response = new List<ApiTeacherSkillResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6cf1603b8b96c63567b9e365a2b4c298</Hash>
</Codenesium>*/