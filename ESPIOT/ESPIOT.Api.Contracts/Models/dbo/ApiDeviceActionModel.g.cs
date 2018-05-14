using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionModel
	{
		public ApiDeviceActionModel()
		{}

		public ApiDeviceActionModel(
			int deviceId,
			string name,
			string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Name = name.ToString();
			this.@Value = @value.ToString();
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
    <Hash>0fc26b3cd538794f9f1719b04c52c9bc</Hash>
</Codenesium>*/