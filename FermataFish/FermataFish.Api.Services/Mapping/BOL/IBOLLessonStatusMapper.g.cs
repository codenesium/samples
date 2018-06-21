using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>02ce552f6f9f474d862bfc98ab596f2d</Hash>
</Codenesium>*/