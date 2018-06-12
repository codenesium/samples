using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractProjectTriggerMapper
        {
                public virtual BOProjectTrigger MapModelToBO(
                        string id,
                        ApiProjectTriggerRequestModel model
                        )
                {
                        BOProjectTrigger boProjectTrigger = new BOProjectTrigger();

                        boProjectTrigger.SetProperties(
                                id,
                                model.IsDisabled,
                                model.JSON,
                                model.Name,
                                model.ProjectId,
                                model.TriggerType);
                        return boProjectTrigger;
                }

                public virtual ApiProjectTriggerResponseModel MapBOToModel(
                        BOProjectTrigger boProjectTrigger)
                {
                        var model = new ApiProjectTriggerResponseModel();

                        model.SetProperties(boProjectTrigger.Id, boProjectTrigger.IsDisabled, boProjectTrigger.JSON, boProjectTrigger.Name, boProjectTrigger.ProjectId, boProjectTrigger.TriggerType);

                        return model;
                }

                public virtual List<ApiProjectTriggerResponseModel> MapBOToModel(
                        List<BOProjectTrigger> items)
                {
                        List<ApiProjectTriggerResponseModel> response = new List<ApiProjectTriggerResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e750041501f894b84f9ccdbd3e61bc61</Hash>
</Codenesium>*/