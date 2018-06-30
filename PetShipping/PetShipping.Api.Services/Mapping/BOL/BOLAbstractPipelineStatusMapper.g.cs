using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractPipelineStatusMapper
        {
                public virtual BOPipelineStatus MapModelToBO(
                        int id,
                        ApiPipelineStatusRequestModel model
                        )
                {
                        BOPipelineStatus boPipelineStatus = new BOPipelineStatus();
                        boPipelineStatus.SetProperties(
                                id,
                                model.Name);
                        return boPipelineStatus;
                }

                public virtual ApiPipelineStatusResponseModel MapBOToModel(
                        BOPipelineStatus boPipelineStatus)
                {
                        var model = new ApiPipelineStatusResponseModel();

                        model.SetProperties(boPipelineStatus.Id, boPipelineStatus.Name);

                        return model;
                }

                public virtual List<ApiPipelineStatusResponseModel> MapBOToModel(
                        List<BOPipelineStatus> items)
                {
                        List<ApiPipelineStatusResponseModel> response = new List<ApiPipelineStatusResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f4c0684baf8f4ab183f5958775d7b864</Hash>
</Codenesium>*/