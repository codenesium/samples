using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPipelineStepMapper
        {
                public virtual BOPipelineStep MapModelToBO(
                        int id,
                        ApiPipelineStepRequestModel model
                        )
                {
                        BOPipelineStep boPipelineStep = new BOPipelineStep();
                        boPipelineStep.SetProperties(
                                id,
                                model.Name,
                                model.PipelineStepStatusId,
                                model.ShipperId);
                        return boPipelineStep;
                }

                public virtual ApiPipelineStepResponseModel MapBOToModel(
                        BOPipelineStep boPipelineStep)
                {
                        var model = new ApiPipelineStepResponseModel();

                        model.SetProperties(boPipelineStep.Id, boPipelineStep.Name, boPipelineStep.PipelineStepStatusId, boPipelineStep.ShipperId);

                        return model;
                }

                public virtual List<ApiPipelineStepResponseModel> MapBOToModel(
                        List<BOPipelineStep> items)
                {
                        List<ApiPipelineStepResponseModel> response = new List<ApiPipelineStepResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3e6a6687ccfc93d96f5c337b9f411236</Hash>
</Codenesium>*/