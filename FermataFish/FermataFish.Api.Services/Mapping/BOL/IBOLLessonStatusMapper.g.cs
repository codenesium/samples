using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLLessonStatusMapper
        {
                BOLessonStatus MapModelToBO(
                        int id,
                        ApiLessonStatusRequestModel model);

                ApiLessonStatusResponseModel MapBOToModel(
                        BOLessonStatus boLessonStatus);

                List<ApiLessonStatusResponseModel> MapBOToModel(
                        List<BOLessonStatus> items);
        }
}

/*<Codenesium>
    <Hash>1f68d5bc24a769d1374d9cd86f56d032</Hash>
</Codenesium>*/