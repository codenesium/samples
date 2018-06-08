using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractTeacherSkillMapper
        {
                public virtual TeacherSkill MapBOToEF(
                        BOTeacherSkill bo)
                {
                        TeacherSkill efTeacherSkill = new TeacherSkill();

                        efTeacherSkill.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.StudioId);
                        return efTeacherSkill;
                }

                public virtual BOTeacherSkill MapEFToBO(
                        TeacherSkill ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTeacherSkill();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.StudioId);
                        return bo;
                }

                public virtual List<BOTeacherSkill> MapEFToBO(
                        List<TeacherSkill> records)
                {
                        List<BOTeacherSkill> response = new List<BOTeacherSkill>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>73490a62a85a6e774b3c02a470582a82</Hash>
</Codenesium>*/