using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
{
	public partial class ApiDeviceActionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDeviceActionClientRequestModel()
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

		[JsonProperty]
		public int DeviceId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string @Value { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c55c937c99f00f5d1cdb3ac16f051d8d</Hash>
</Codenesium>*/