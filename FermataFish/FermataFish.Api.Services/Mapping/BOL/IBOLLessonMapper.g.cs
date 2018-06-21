using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>dac22bc98e9887af22a82b5afbbcae30</Hash>
</Codenesium>*/