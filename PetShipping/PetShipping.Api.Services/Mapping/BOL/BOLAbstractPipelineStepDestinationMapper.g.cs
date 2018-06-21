using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPipelineStepDestinationMapper
        {
                public virtual BOPipelineStepDestination MapModelToBO(
                        int id,
                        ApiPipelineStepDestinationRequestModel model
                        )
                {
                        BOPipelineStepDestination boPipelineStepDestination = new BOPipelineStepDestination();
                        boPipelineStepDestination.SetProperties(
                                id,
                                model.DestinationId,
                                model.PipelineStepId);
                        return boPipelineStepDestination;
                }

                public virtual ApiPipelineStepDestinationResponseModel MapBOToModel(
                        BOPipelineStepDestination boPipelineStepDestination)
                {
                        var model = new ApiPipelineStepDestinationResponseModel();

                        model.SetProperties(boPipelineStepDestination.DestinationId, boPipelineStepDestination.Id, boPipelineStepDestination.PipelineStepId);

                        return model;
                }

                public virtual List<ApiPipelineStepDestinationResponseModel> MapBOToModel(
                        List<BOPipelineStepDestination> items)
                {
                        List<ApiPipelineStepDestinationResponseModel> response = new List<ApiPipelineStepDestinationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6c5c8843e3a88b9c9c0b9e7fc1e37adb</Hash>
</Codenesium>*/