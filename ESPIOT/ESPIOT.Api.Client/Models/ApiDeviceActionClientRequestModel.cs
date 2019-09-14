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
    <Hash>9650c4add1bda9dcd7ab2a18000ff3cc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/