using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int deviceId,
			string name,
			string @value)
		{
			this.Id = id;
			this.DeviceId = deviceId;
			this.Name = name;
			this.@Value = @value;

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
    <Hash>1bbaeb0c94d89a8ce149e1a074ac29ed</Hash>
</Codenesium>*/