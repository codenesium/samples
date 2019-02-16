using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiDeviceActionClientResponseModel : AbstractApiClientResponseModel
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

			this.DeviceIdEntity = nameof(ApiResponse.Devices);
		}

		[JsonProperty]
		public ApiDeviceClientResponseModel DeviceIdNavigation { get; private set; }

		public void SetDeviceIdNavigation(ApiDeviceClientResponseModel value)
		{
			this.DeviceIdNavigation = value;
		}

		[JsonProperty]
		public string Action { get; private set; }

		[JsonProperty]
		public int DeviceId { get; private set; }

		[JsonProperty]
		public string DeviceIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a75c7d56edb7cc848ec060acb46f6b13</Hash>
</Codenesium>*/