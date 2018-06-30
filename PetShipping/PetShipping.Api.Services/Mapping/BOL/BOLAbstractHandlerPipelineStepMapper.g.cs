using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractHandlerPipelineStepMapper
        {
                public virtual BOHandlerPipelineStep MapModelToBO(
                        int id,
                        ApiHandlerPipelineStepRequestModel model
                        )
                {
                        BOHandlerPipelineStep boHandlerPipelineStep = new BOHandlerPipelineStep();
                        boHandlerPipelineStep.SetProperties(
                                id,
                                model.HandlerId,
                                model.PipelineStepId);
                        return boHandlerPipelineStep;
                }

                public virtual ApiHandlerPipelineStepResponseModel MapBOToModel(
                        BOHandlerPipelineStep boHandlerPipelineStep)
                {
                        var model = new ApiHandlerPipelineStepResponseModel();

                        model.SetProperties(boHandlerPipelineStep.Id, boHandlerPipelineStep.HandlerId, boHandlerPipelineStep.PipelineStepId);

                        return model;
                }

                public virtual List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
                        List<BOHandlerPipelineStep> items)
                {
                        List<ApiHandlerPipelineStepResponseModel> response = new List<ApiHandlerPipelineStepResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a1bbaf3f67f989e87b6200403f99a9a8</Hash>
</Codenesium>*/