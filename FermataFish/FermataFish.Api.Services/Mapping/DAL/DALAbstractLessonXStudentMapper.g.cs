using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractLessonXStudentMapper
        {
                public virtual LessonXStudent MapBOToEF(
                        BOLessonXStudent bo)
                {
                        LessonXStudent efLessonXStudent = new LessonXStudent();

                        efLessonXStudent.SetProperties(
                                bo.Id,
                                bo.LessonId,
                                bo.StudentId);
                        return efLessonXStudent;
                }

                public virtual BOLessonXStudent MapEFToBO(
                        LessonXStudent ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOLessonXStudent();

                        bo.SetProperties(
                                ef.Id,
                                ef.LessonId,
                                ef.StudentId);
                        return bo;
                }

                public virtual List<BOLessonXStudent> MapEFToBO(
                        List<LessonXStudent> records)
                {
                        List<BOLessonXStudent> response = new List<BOLessonXStudent>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9478af38cfc2971851c010b680c3ae39</Hash>
</Codenesium>*/