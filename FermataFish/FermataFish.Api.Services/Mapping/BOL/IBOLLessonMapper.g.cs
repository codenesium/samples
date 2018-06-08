using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLLessonMapper
        {
                BOLesson MapModelToBO(
                        int id,
                        ApiLessonRequestModel model);

                ApiLessonResponseModel MapBOToModel(
                        BOLesson boLesson);

                List<ApiLessonResponseModel> MapBOToModel(
                        List<BOLesson> items);
        }
}

/*<Codenesium>
    <Hash>f7d0326a1412c3e39d816099d943d29b</Hash>
</Codenesium>*/