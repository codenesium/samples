using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPipelineStepStepRequirementMapper
        {
                public virtual BOPipelineStepStepRequirement MapModelToBO(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel model
                        )
                {
                        BOPipelineStepStepRequirement boPipelineStepStepRequirement = new BOPipelineStepStepRequirement();

                        boPipelineStepStepRequirement.SetProperties(
                                id,
                                model.Details,
                                model.PipelineStepId,
                                model.RequirementMet);
                        return boPipelineStepStepRequirement;
                }

                public virtual ApiPipelineStepStepRequirementResponseModel MapBOToModel(
                        BOPipelineStepStepRequirement boPipelineStepStepRequirement)
                {
                        var model = new ApiPipelineStepStepRequirementResponseModel();

                        model.SetProperties(boPipelineStepStepRequirement.Details, boPipelineStepStepRequirement.Id, boPipelineStepStepRequirement.PipelineStepId, boPipelineStepStepRequirement.RequirementMet);

                        return model;
                }

                public virtual List<ApiPipelineStepStepRequirementResponseModel> MapBOToModel(
                        List<BOPipelineStepStepRequirement> items)
                {
                        List<ApiPipelineStepStepRequirementResponseModel> response = new List<ApiPipelineStepStepRequirementResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3db9864a0d04fea1120bc6aece933349</Hash>
</Codenesium>*/