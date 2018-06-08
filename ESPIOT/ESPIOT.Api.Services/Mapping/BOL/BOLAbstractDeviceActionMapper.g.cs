using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public abstract class BOLAbstractDeviceActionMapper
        {
                public virtual BODeviceAction MapModelToBO(
                        int id,
                        ApiDeviceActionRequestModel model
                        )
                {
                        BODeviceAction boDeviceAction = new BODeviceAction();

                        boDeviceAction.SetProperties(
                                id,
                                model.DeviceId,
                                model.Name,
                                model.@Value);
                        return boDeviceAction;
                }

                public virtual ApiDeviceActionResponseModel MapBOToModel(
                        BODeviceAction boDeviceAction)
                {
                        var model = new ApiDeviceActionResponseModel();

                        model.SetProperties(boDeviceAction.DeviceId, boDeviceAction.Id, boDeviceAction.Name, boDeviceAction.@Value);

                        return model;
                }

                public virtual List<ApiDeviceActionResponseModel> MapBOToModel(
                        List<BODeviceAction> items)
                {
                        List<ApiDeviceActionResponseModel> response = new List<ApiDeviceActionResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>446c61709745988d3597e64e8d29e8a6</Hash>
</Codenesium>*/