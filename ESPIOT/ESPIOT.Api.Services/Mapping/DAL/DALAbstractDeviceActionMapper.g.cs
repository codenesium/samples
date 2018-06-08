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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>8e7362535a55c6cf50597d5ac30cd02e</Hash>
</Codenesium>*/