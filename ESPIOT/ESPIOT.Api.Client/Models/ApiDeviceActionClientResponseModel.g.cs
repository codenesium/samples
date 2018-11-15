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
			string @value,
			int deviceId,
			string name)
		{
			this.Id = id;
			this.@Value = @value;
			this.DeviceId = deviceId;
			this.Name = name;

			this.DeviceIdEntity = nameof(ApiResponse.Devices);
		}

		[JsonProperty]
		public int DeviceId { get; private set; }

		[JsonProperty]
		public string DeviceIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string @Value { get; private set; }
	}
}

/*<Codenesium>
    <Hash>51a0f13a6ec631566a289c9b986ec9f3</Hash>
</Codenesium>*/