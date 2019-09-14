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
    <Hash>89c16459fa4d49677d77a01e23643bdc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/