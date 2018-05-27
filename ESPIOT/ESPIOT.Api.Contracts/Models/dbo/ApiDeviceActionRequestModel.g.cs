using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionRequestModel: AbstractApiRequestModel
	{
		public ApiDeviceActionRequestModel() : base()
		{}

		public void SetProperties(
			int deviceId,
			string name,
			string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		private int deviceId;

		[Required]
		public int DeviceId
		{
			get
			{
				return this.deviceId;
			}

			set
			{
				this.deviceId = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private string @value;

		[Required]
		public string @Value
		{
			get
			{
				return this.@value;
			}

			set
			{
				this.@value = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>219626572f75d25b7a14e400d77d373c</Hash>
</Codenesium>*/