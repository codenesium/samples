using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceActionModel: AbstractModel
	{
		public ApiDeviceActionModel() : base()
		{}

		public ApiDeviceActionModel(
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
    <Hash>4d31cedc7f38fcf3cc5d595e577774c7</Hash>
</Codenesium>*/