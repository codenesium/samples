using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

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
    <Hash>6b463148079e727d6eebda6c78409b5c</Hash>
</Codenesium>*/