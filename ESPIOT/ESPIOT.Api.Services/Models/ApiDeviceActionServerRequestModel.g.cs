using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Services
{
	public partial class ApiDeviceActionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDeviceActionServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string @value,
			int deviceId,
			string name)
		{
			this.@Value = @value;
			this.DeviceId = deviceId;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public int DeviceId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string @Value { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a630e0a07ee8f0cbb18b82c0189ec98e</Hash>
</Codenesium>*/