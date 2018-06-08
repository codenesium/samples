using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractTeacherXTeacherSkillMapper
        {
                public virtual TeacherXTeacherSkill MapBOToEF(
                        BOTeacherXTeacherSkill bo)
                {
                        TeacherXTeacherSkill efTeacherXTeacherSkill = new TeacherXTeacherSkill();

                        efTeacherXTeacherSkill.SetProperties(
                                bo.Id,
                                bo.TeacherId,
                                bo.TeacherSkillId);
                        return efTeacherXTeacherSkill;
                }

                public virtual BOTeacherXTeacherSkill MapEFToBO(
                        TeacherXTeacherSkill ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTeacherXTeacherSkill();

                        bo.SetProperties(
                                ef.Id,
                                ef.TeacherId,
                                ef.TeacherSkillId);
                        return bo;
                }

                public virtual List<BOTeacherXTeacherSkill> MapEFToBO(
                        List<TeacherXTeacherSkill> records)
                {
                        List<BOTeacherXTeacherSkill> response = new List<BOTeacherXTeacherSkill>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>186afa0281f1d2d0ac11d6177fc8b412</Hash>
</Codenesium>*/