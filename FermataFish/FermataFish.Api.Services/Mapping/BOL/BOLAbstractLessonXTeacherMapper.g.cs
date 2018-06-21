using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0a080e9dc7a33f42c2c4df816a4e5fd5</Hash>
</Codenesium>*/