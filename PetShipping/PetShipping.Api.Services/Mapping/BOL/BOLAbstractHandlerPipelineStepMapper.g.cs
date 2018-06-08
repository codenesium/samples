using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                        model.SetProperties(boHandlerPipelineStep.HandlerId, boHandlerPipelineStep.Id, boHandlerPipelineStep.PipelineStepId);

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
    <Hash>3ac6caea203e50d1a5e3441a7cfed283</Hash>
</Codenesium>*/