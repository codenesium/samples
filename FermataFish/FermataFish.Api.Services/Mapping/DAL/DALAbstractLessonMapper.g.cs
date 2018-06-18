using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractLessonMapper
        {
                public virtual Lesson MapBOToEF(
                        BOLesson bo)
                {
                        Lesson efLesson = new Lesson();

                        efLesson.SetProperties(
                                bo.ActualEndDate,
                                bo.ActualStartDate,
                                bo.BillAmount,
                                bo.Id,
                                bo.LessonStatusId,
                                bo.ScheduledEndDate,
                                bo.ScheduledStartDate,
                                bo.StudentNotes,
                                bo.StudioId,
                                bo.TeacherNotes);
                        return efLesson;
                }

                public virtual BOLesson MapEFToBO(
                        Lesson ef)
                {
                        var bo = new BOLesson();

                        bo.SetProperties(
                                ef.Id,
                                ef.ActualEndDate,
                                ef.ActualStartDate,
                                ef.BillAmount,
                                ef.LessonStatusId,
                                ef.ScheduledEndDate,
                                ef.ScheduledStartDate,
                                ef.StudentNotes,
                                ef.StudioId,
                                ef.TeacherNotes);
                        return bo;
                }

                public virtual List<BOLesson> MapEFToBO(
                        List<Lesson> records)
                {
                        List<BOLesson> response = new List<BOLesson>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>294bad2796463ba9bd4feabc5405c27a</Hash>
</Codenesium>*/