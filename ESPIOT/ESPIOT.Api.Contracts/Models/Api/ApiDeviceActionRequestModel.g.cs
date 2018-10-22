using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string @Value { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a394e84cb1be21676bd10e4daaf157ce</Hash>
</Codenesium>*/