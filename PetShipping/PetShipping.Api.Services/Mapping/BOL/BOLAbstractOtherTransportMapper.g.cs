using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractOtherTransportMapper
        {
                public virtual BOOtherTransport MapModelToBO(
                        int id,
                        ApiOtherTransportRequestModel model
                        )
                {
                        BOOtherTransport boOtherTransport = new BOOtherTransport();

                        boOtherTransport.SetProperties(
                                id,
                                model.HandlerId,
                                model.PipelineStepId);
                        return boOtherTransport;
                }

                public virtual ApiOtherTransportResponseModel MapBOToModel(
                        BOOtherTransport boOtherTransport)
                {
                        var model = new ApiOtherTransportResponseModel();

                        model.SetProperties(boOtherTransport.HandlerId, boOtherTransport.Id, boOtherTransport.PipelineStepId);

                        return model;
                }

                public virtual List<ApiOtherTransportResponseModel> MapBOToModel(
                        List<BOOtherTransport> items)
                {
                        List<ApiOtherTransportResponseModel> response = new List<ApiOtherTransportResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1bea27f25e1c466f12fc003a524479a9</Hash>
</Codenesium>*/