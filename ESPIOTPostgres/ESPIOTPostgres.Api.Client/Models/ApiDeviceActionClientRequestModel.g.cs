using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTPostgresNS.Api.Client
{
	public partial class ApiDeviceActionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDeviceActionClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string action,
			int deviceId,
			string name)
		{
			this.Action = action;
			this.DeviceId = deviceId;
			this.Name = name;
		}

		[JsonProperty]
		public string Action { get; private set; } = default(string);

		[JsonProperty]
		public int DeviceId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>0a1e468c4838b739ea974b6ac0209c74</Hash>
</Codenesium>*/