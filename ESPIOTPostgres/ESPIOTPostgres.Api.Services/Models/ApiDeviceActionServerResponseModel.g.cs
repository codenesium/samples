using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial class ApiDeviceActionServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string action,
			int deviceId,
			string name)
		{
			this.Id = id;
			this.Action = action;
			this.DeviceId = deviceId;
			this.Name = name;
		}

		[JsonProperty]
		public string Action { get; private set; }

		[JsonProperty]
		public int DeviceId { get; private set; }

		[JsonProperty]
		public string DeviceIdEntity { get; private set; } = RouteConstants.Devices;

		[JsonProperty]
		public ApiDeviceServerResponseModel DeviceIdNavigation { get; private set; }

		public void SetDeviceIdNavigation(ApiDeviceServerResponseModel value)
		{
			this.DeviceIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c6318d58d1dedf5bc0d84ca12ba70177</Hash>
</Codenesium>*/