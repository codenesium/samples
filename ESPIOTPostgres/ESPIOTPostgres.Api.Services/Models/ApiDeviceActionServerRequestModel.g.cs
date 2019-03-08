using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial class ApiDeviceActionServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDeviceActionServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Action { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int DeviceId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>1ae0bfe5eb84cea4f83fd0cd473f1805</Hash>
</Codenesium>*/