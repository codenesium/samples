using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public abstract class BOLAbstractDeviceMapper
        {
                public virtual BODevice MapModelToBO(
                        int id,
                        ApiDeviceRequestModel model
                        )
                {
                        BODevice boDevice = new BODevice();

                        boDevice.SetProperties(
                                id,
                                model.Name,
                                model.PublicId);
                        return boDevice;
                }

                public virtual ApiDeviceResponseModel MapBOToModel(
                        BODevice boDevice)
                {
                        var model = new ApiDeviceResponseModel();

                        model.SetProperties(boDevice.Id, boDevice.Name, boDevice.PublicId);

                        return model;
                }

                public virtual List<ApiDeviceResponseModel> MapBOToModel(
                        List<BODevice> items)
                {
                        List<ApiDeviceResponseModel> response = new List<ApiDeviceResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0e4282af29bc0b7524b428000c02534c</Hash>
</Codenesium>*/