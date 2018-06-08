using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractLessonMapper
        {
                public virtual BOLesson MapModelToBO(
                        int id,
                        ApiLessonRequestModel model
                        )
                {
                        BOLesson boLesson = new BOLesson();

                        boLesson.SetProperties(
                                id,
                                model.ActualEndDate,
                                model.ActualStartDate,
                                model.BillAmount,
                                model.LessonStatusId,
                                model.ScheduledEndDate,
                                model.ScheduledStartDate,
                                model.StudentNotes,
                                model.StudioId,
                                model.TeacherNotes);
                        return boLesson;
                }

                public virtual ApiLessonResponseModel MapBOToModel(
                        BOLesson boLesson)
                {
                        var model = new ApiLessonResponseModel();

                        model.SetProperties(boLesson.ActualEndDate, boLesson.ActualStartDate, boLesson.BillAmount, boLesson.Id, boLesson.LessonStatusId, boLesson.ScheduledEndDate, boLesson.ScheduledStartDate, boLesson.StudentNotes, boLesson.StudioId, boLesson.TeacherNotes);

                        return model;
                }

                public virtual List<ApiLessonResponseModel> MapBOToModel(
                        List<BOLesson> items)
                {
                        List<ApiLessonResponseModel> response = new List<ApiLessonResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7eec7759853b196a7b6eca9bc5fce834</Hash>
</Codenesium>*/