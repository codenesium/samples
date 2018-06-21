using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ESPIOTNS.Api.Services
{
        public abstract class DALAbstractDeviceActionMapper
        {
                public virtual DeviceAction MapBOToEF(
                        BODeviceAction bo)
                {
                        DeviceAction efDeviceAction = new DeviceAction();
                        efDeviceAction.SetProperties(
                                bo.DeviceId,
                                bo.Id,
                                bo.Name,
                                bo.@Value);
                        return efDeviceAction;
                }

                public virtual BODeviceAction MapEFToBO(
                        DeviceAction ef)
                {
                        var bo = new BODeviceAction();

                        bo.SetProperties(
                                ef.Id,
                                ef.DeviceId,
                                ef.Name,
                                ef.@Value);
                        return bo;
                }

                public virtual List<BODeviceAction> MapEFToBO(
                        List<DeviceAction> records)
                {
                        List<BODeviceAction> response = new List<BODeviceAction>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>171e0dafd78801470c035d76d81fe6a5</Hash>
</Codenesium>*/