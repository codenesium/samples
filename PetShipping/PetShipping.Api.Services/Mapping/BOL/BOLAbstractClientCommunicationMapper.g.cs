using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractClientCommunicationMapper
        {
                public virtual BOClientCommunication MapModelToBO(
                        int id,
                        ApiClientCommunicationRequestModel model
                        )
                {
                        BOClientCommunication boClientCommunication = new BOClientCommunication();

                        boClientCommunication.SetProperties(
                                id,
                                model.ClientId,
                                model.DateCreated,
                                model.EmployeeId,
                                model.Notes);
                        return boClientCommunication;
                }

                public virtual ApiClientCommunicationResponseModel MapBOToModel(
                        BOClientCommunication boClientCommunication)
                {
                        var model = new ApiClientCommunicationResponseModel();

                        model.SetProperties(boClientCommunication.ClientId, boClientCommunication.DateCreated, boClientCommunication.EmployeeId, boClientCommunication.Id, boClientCommunication.Notes);

                        return model;
                }

                public virtual List<ApiClientCommunicationResponseModel> MapBOToModel(
                        List<BOClientCommunication> items)
                {
                        List<ApiClientCommunicationResponseModel> response = new List<ApiClientCommunicationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>752b4c01b572759b6a47503a23929dc2</Hash>
</Codenesium>*/