using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractLifecycleMapper
        {
                public virtual BOLifecycle MapModelToBO(
                        string id,
                        ApiLifecycleRequestModel model
                        )
                {
                        BOLifecycle boLifecycle = new BOLifecycle();

                        boLifecycle.SetProperties(
                                id,
                                model.DataVersion,
                                model.JSON,
                                model.Name);
                        return boLifecycle;
                }

                public virtual ApiLifecycleResponseModel MapBOToModel(
                        BOLifecycle boLifecycle)
                {
                        var model = new ApiLifecycleResponseModel();

                        model.SetProperties(boLifecycle.DataVersion, boLifecycle.Id, boLifecycle.JSON, boLifecycle.Name);

                        return model;
                }

                public virtual List<ApiLifecycleResponseModel> MapBOToModel(
                        List<BOLifecycle> items)
                {
                        List<ApiLifecycleResponseModel> response = new List<ApiLifecycleResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8bbb6cb392c5ae7dea7846d394764ec0</Hash>
</Codenesium>*/