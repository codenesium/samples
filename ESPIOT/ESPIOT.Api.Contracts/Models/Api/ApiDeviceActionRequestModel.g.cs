using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionRequestModel : AbstractApiRequestModel
	{
		public ApiDeviceActionRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int deviceId,
			string name,
			string @value)
		{
			this.DeviceId = deviceId;
			this.Name = name;
			this.@Value = @value;
		}

		[Required]
		[JsonProperty]
		public int DeviceId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string @Value { get; private set; }
	}
}

/*<Codenesium>
    <Hash>760fbeea647149ecc1ea3da6f3c6f493</Hash>
</Codenesium>*/