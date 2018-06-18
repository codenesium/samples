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
    <Hash>e90f176b441e495b2f057b4501bf8fa2</Hash>
</Codenesium>*/