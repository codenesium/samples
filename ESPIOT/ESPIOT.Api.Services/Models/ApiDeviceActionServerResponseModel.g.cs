using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiDeviceActionServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>8b349de6158a6a2416eb050663e37719</Hash>
</Codenesium>*/