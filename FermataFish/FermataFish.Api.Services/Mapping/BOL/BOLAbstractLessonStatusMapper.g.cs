using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractLessonStatusMapper
        {
                public virtual BOLessonStatus MapModelToBO(
                        int id,
                        ApiLessonStatusRequestModel model
                        )
                {
                        BOLessonStatus boLessonStatus = new BOLessonStatus();
                        boLessonStatus.SetProperties(
                                id,
                                model.Name,
                                model.StudioId);
                        return boLessonStatus;
                }

                public virtual ApiLessonStatusResponseModel MapBOToModel(
                        BOLessonStatus boLessonStatus)
                {
                        var model = new ApiLessonStatusResponseModel();

                        model.SetProperties(boLessonStatus.Id, boLessonStatus.Name, boLessonStatus.StudioId);

                        return model;
                }

                public virtual List<ApiLessonStatusResponseModel> MapBOToModel(
                        List<BOLessonStatus> items)
                {
                        List<ApiLessonStatusResponseModel> response = new List<ApiLessonStatusResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9bd7441bb7dfd90bd3205af3735e4c21</Hash>
</Codenesium>*/