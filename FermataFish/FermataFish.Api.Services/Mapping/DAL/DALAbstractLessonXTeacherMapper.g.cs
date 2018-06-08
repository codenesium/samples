using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractLessonXTeacherMapper
        {
                public virtual LessonXTeacher MapBOToEF(
                        BOLessonXTeacher bo)
                {
                        LessonXTeacher efLessonXTeacher = new LessonXTeacher();

                        efLessonXTeacher.SetProperties(
                                bo.Id,
                                bo.LessonId,
                                bo.StudentId);
                        return efLessonXTeacher;
                }

                public virtual BOLessonXTeacher MapEFToBO(
                        LessonXTeacher ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOLessonXTeacher();

                        bo.SetProperties(
                                ef.Id,
                                ef.LessonId,
                                ef.StudentId);
                        return bo;
                }

                public virtual List<BOLessonXTeacher> MapEFToBO(
                        List<LessonXTeacher> records)
                {
                        List<BOLessonXTeacher> response = new List<BOLessonXTeacher>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>36ac0f8d4a273ed3f587ca7a48f88c71</Hash>
</Codenesium>*/