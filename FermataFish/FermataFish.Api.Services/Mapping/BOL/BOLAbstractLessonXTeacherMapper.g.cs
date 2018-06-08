using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractLessonXTeacherMapper
        {
                public virtual BOLessonXTeacher MapModelToBO(
                        int id,
                        ApiLessonXTeacherRequestModel model
                        )
                {
                        BOLessonXTeacher boLessonXTeacher = new BOLessonXTeacher();

                        boLessonXTeacher.SetProperties(
                                id,
                                model.LessonId,
                                model.StudentId);
                        return boLessonXTeacher;
                }

                public virtual ApiLessonXTeacherResponseModel MapBOToModel(
                        BOLessonXTeacher boLessonXTeacher)
                {
                        var model = new ApiLessonXTeacherResponseModel();

                        model.SetProperties(boLessonXTeacher.Id, boLessonXTeacher.LessonId, boLessonXTeacher.StudentId);

                        return model;
                }

                public virtual List<ApiLessonXTeacherResponseModel> MapBOToModel(
                        List<BOLessonXTeacher> items)
                {
                        List<ApiLessonXTeacherResponseModel> response = new List<ApiLessonXTeacherResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5f0e58c34d7c0ba066d7fdbac6d4ece1</Hash>
</Codenesium>*/