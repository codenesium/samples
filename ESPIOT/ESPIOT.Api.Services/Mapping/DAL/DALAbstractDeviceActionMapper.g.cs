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
				bo.@Value,
				bo.DeviceId,
				bo.Id,
				bo.Name);
			return efDeviceAction;
		}

		public virtual BODeviceAction MapEFToBO(
			DeviceAction ef)
		{
			var bo = new BODeviceAction();

			bo.SetProperties(
				ef.Id,
				ef.@Value,
				ef.DeviceId,
				ef.Name);
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
    <Hash>99d0ff30460e2eee332cfda2b15262ef</Hash>
</Codenesium>*/